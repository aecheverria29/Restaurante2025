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
        public FacturacionForm() : this(null) { }

        public FacturacionForm(MainForm mainForm)
        {
            InitializeComponent();
            main = mainForm;
            PersonalizarEstilo();
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
            dgvPedidos.CellContentClick += dgvPedidos_CellContentClick;
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

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void PersonalizarEstilo()
        {
            // Fondo claro moderno
            this.BackColor = Color.FromArgb(246, 247, 251);

            // --- Label de encabezado ---
            label1.Text = "Lista de pedidos entregados no facturados";
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(49, 70, 194);
            label1.AutoSize = true;
            label1.Top = 18;
            label1.Left = 28;

            // --- DataGridView de pedidos ---
            dgvPedidos.Top = label1.Bottom + 6;
            dgvPedidos.Left = label1.Left;
            dgvPedidos.Width = this.ClientSize.Width - 65;
            dgvPedidos.Height = 170;
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvPedidos.DefaultCellStyle.BackColor = Color.White;
            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // --- Botón Cobrar ---
            btnCobrar.Text = "Cobrar";
            btnCobrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCobrar.Width = 92;
            btnCobrar.Height = 36;
            btnCobrar.BackColor = Color.FromArgb(39, 174, 96);
            btnCobrar.ForeColor = Color.White;
            btnCobrar.FlatStyle = FlatStyle.Flat;
            btnCobrar.FlatAppearance.BorderSize = 0;
            btnCobrar.Cursor = Cursors.Hand;
            btnCobrar.Top = dgvPedidos.Top + 14;
            btnCobrar.Left = dgvPedidos.Right - btnCobrar.Width + 10;
            btnCobrar.MouseEnter += (s, e) => btnCobrar.BackColor = ControlPaint.Dark(btnCobrar.BackColor);
            btnCobrar.MouseLeave += (s, e) => btnCobrar.BackColor = Color.FromArgb(39, 174, 96);

            // --- Label para detalle ---
            Label lblDetalle = new Label();
            lblDetalle.Text = "DETALLE DE LOS PEDIDOS";
            lblDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDetalle.ForeColor = Color.FromArgb(44, 62, 80);
            lblDetalle.AutoSize = true;
            lblDetalle.Top = dgvPedidos.Bottom + 18;
            lblDetalle.Left = label1.Left;
            this.Controls.Add(lblDetalle);

            // --- DataGridView de detalle ---
            dgvDetallePedido.Left = label1.Left;
            dgvDetallePedido.Top = lblDetalle.Bottom + 6;
            dgvDetallePedido.Width = dgvPedidos.Width;
            dgvDetallePedido.Height = 150;
            dgvDetallePedido.BackgroundColor = Color.White;
            dgvDetallePedido.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvDetallePedido.DefaultCellStyle.BackColor = Color.White;
            dgvDetallePedido.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvDetallePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // --- Ajustar tamaño del formulario si es necesario ---
            this.Width = dgvDetallePedido.Right + 40;
            this.Height = dgvDetallePedido.Bottom + 55;
        }

    }
}
