using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class PedidosForm : Form
    {
        public PedidosForm()
        {
            InitializeComponent();
            this.Load += PedidosForm_Load;
            dgvPedidos.CellClick += dgvPedidos_CellClick;
        }
        private void CargarPedidos(string estadoFiltro = "Todos")
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                StringBuilder query = new StringBuilder(@"
                    SELECT p.IdPedido, p.Fecha, m.NumeroMesa, ep.NombreEstado, tc.NombreTipo
                    FROM Pedidos p
                    INNER JOIN Mesas m ON p.IdMesa = m.IdMesa
                    INNER JOIN EstadoPedido ep ON p.IdEstadoPedido = ep.IdEstadoPedido
                    INNER JOIN TiposConsumo tc ON p.IdTipoConsumo = tc.IdTipoConsumo
                    WHERE 1 = 1");
                if (estadoFiltro != "Todos")
                    query.Append(" AND ep.NombreEstado = @estado ");
                SqlCommand cmd = new SqlCommand(query.ToString(), conn);

                if (estadoFiltro != "Todos")
                    cmd.Parameters.AddWithValue("@estado",estadoFiltro);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPedidos.DataSource = dt;

                if (dgvPedidos.Columns.Contains("IdPedido"))
                    dgvPedidos.Columns["IdPedido"].Visible = false; 
            }
        }
        private void CargarEstados()
        {
            cbEstadoFiltro.Items.Clear();
            cbEstadoFiltro.Items.Add("Todos");
            
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT NombreEstado FROM EstadoPedido", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbEstadoFiltro.Items.Add(reader["NombreEstado"].ToString());
                }
            }

            cbEstadoFiltro.SelectedIndex = 0;
        }
        private void PedidosForm_Load(object sender, EventArgs e)
        {
            CargarEstados();
            cbEstadoFiltro.SelectedItem = "Pendiente";
            CargarPedidos("Pendiente");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string estado = cbEstadoFiltro.SelectedItem?.ToString() ?? "Todos";
            CargarPedidos(estado);
        }

        private void CargarDetallePedido(int idPedido)
        {
            using(SqlConnection conn = DBConnection.GetConnection())
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

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                DataGridViewRow row = dgvPedidos.Rows[e.RowIndex];
                int idPedido = Convert.ToInt32(row.Cells["IdPedido"].Value);
                CargarDetallePedido(idPedido);
            }
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                int idPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdPedido"].Value);
                string estadoActual = dgvPedidos.CurrentRow.Cells["NombreEstado"].Value.ToString();
                int nuevoIdEstado = -1;

                if (estadoActual == "Pendiente") nuevoIdEstado = 2;
                else if (estadoActual == "En preparación") nuevoIdEstado = 3;
                else
                {
                    MessageBox.Show("Este pedido ya fue entregado o cancelado");
                    return;
                }
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Pedidos SET IdEstadoPedido = @nuevoEstado WHERE IdPedido = @id", conn);
                    cmd.Parameters.AddWithValue("@nuevoEstado", nuevoIdEstado);
                    cmd.Parameters.AddWithValue("@id", idPedido);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Estado Actualizado");
                string filtro = cbEstadoFiltro.SelectedItem?.ToString() ?? "Pendiente";
                CargarPedidos(filtro);
            }
            else
            {
                MessageBox.Show("Selecciona un pedido");
            }

           
        }

        private void btnPedidoNuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            NuevoPedidoForm nuevo = new NuevoPedidoForm();
            nuevo.Show();
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            this.Hide();
            EditarPedidoForm editarPedidoForm = new EditarPedidoForm();
            editarPedidoForm.Show();
        }
    }
}
