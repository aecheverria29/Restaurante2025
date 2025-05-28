using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class FacturacionForm : Form
    {
        private MainForm main;

        public FacturacionForm(MainForm mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        private void CargarDetallePedido(int idPedido)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT dp.Cantidad, p.Nombre, dp.PrecioUnitario, dp.SubTotal, dp.Comentarios
                    FROM DetallePedido dp
                    INNER JOIN Platos p ON dp.IdPlato = p.IdPlato
                    WHERE dp.IdPedido = @idPedido";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvDetallePedido.DataSource = dt;
            }
        }
        private void btnCobrar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                int idPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdPedido"].Value);
                main.CargarFormulario(new SeleccionarTipoDocumentoForm(main, idPedido));
            }
            else
            {
                MessageBox.Show("Selecciona un pedido primero.");
            }
        }

        private void FacturacionForm_Load(object sender, EventArgs e)
        {
            CargarPedidosEntregadosNoFacturados();
        }

        private void CargarPedidosEntregadosNoFacturados()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT p.IdPedido, m.NumeroMesa, p.Fecha, tc.NombreTipo,
                        SUM(dp.Subtotal) AS Total
                    FROM Pedidos p
                    LEFT JOIN Mesas m ON p.IdMesa = m.IdMesa
                    INNER JOIN DetallePedido dp ON p.IdPedido = dp.IdPedido
                    INNER JOIN TiposConsumo tc ON p.IdTipoConsumo = tc.IdTipoConsumo
                    WHERE p.IdEstadoPedido = 3 -- Entregado
                    AND tc.NombreTipo IN ('Cliente', 'Para llevar') -- Solo esos dos tipos
                    AND NOT EXISTS (
                        SELECT 1 FROM Facturas f WHERE f.IdPedido = p.IdPedido AND f.Pagado = 1
                    )
                    GROUP BY p.IdPedido, m.NumeroMesa, p.Fecha, tc.NombreTipo
                    ORDER BY p.Fecha DESC", conn);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPedidos.DataSource = dt;
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >=0)
                {
                    DataGridViewRow row = dgvPedidos.Rows[e.RowIndex];
                    int idPedido = Convert.ToInt32(row.Cells["IdPedido"].Value);
                    CargarDetallePedido(idPedido);
                }
            }
            catch { }
        }
    }
}
