using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class PedidosForm : Form
    {
        private MainForm main;
        public PedidosForm(MainForm mainForm)
        {
            InitializeComponent();
            this.Load += PedidosForm_Load;
            dgvPedidos.CellClick += dgvPedidos_CellClick;
            main = mainForm;

            // Aplica estilos cuando el form está listo
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo general
            this.BackColor = Color.FromArgb(246, 247, 251);

            // ComboBox filtro
            cbEstadoFiltro.Font = new Font("Segoe UI", 11F);
            cbEstadoFiltro.Width = 180;
            cbEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstadoFiltro.BackColor = Color.White;
            cbEstadoFiltro.Left = 38;
            cbEstadoFiltro.Top = 30;

            // Botón Filtrar
            btnFiltrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFiltrar.BackColor = Color.FromArgb(49, 130, 206);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.Width = 90;
            btnFiltrar.Height = 35;
            btnFiltrar.Left = cbEstadoFiltro.Right + 12;
            btnFiltrar.Top = cbEstadoFiltro.Top - 1;

            // Botones de acciones principales
            Button[] acciones = { btnPedidoNuevo, btnEditarPedido, btnCambiarEstado };
            Color[] colores = {
                Color.SeaGreen, Color.RoyalBlue, Color.Orange
            };
            string[] textos = { "Pedido Nuevo", "Editar Pedido", "Cambiar Estado" };
            int anchoBtn = 150, altoBtn = 38, gapX = 18;
            int leftBtn = btnFiltrar.Right + 40;

            for (int i = 0; i < acciones.Length; i++)
            {
                var btn = acciones[i];
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btn.Text = textos[i];
                btn.Width = anchoBtn;
                btn.Height = altoBtn;
                btn.Top = btnFiltrar.Top - 2;
                btn.Left = leftBtn + i * (anchoBtn + gapX);
                btn.BackColor = colores[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }

            // DataGridView de Pedidos
            dgvPedidos.Top = btnFiltrar.Bottom + 30;
            dgvPedidos.Left = cbEstadoFiltro.Left;
            dgvPedidos.Width = this.ClientSize.Width - 2 * dgvPedidos.Left;
            dgvPedidos.Height = 220;
            dgvPedidos.BackgroundColor = Color.White;
            dgvPedidos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvPedidos.DefaultCellStyle.BackColor = Color.White;
            dgvPedidos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(189, 216, 255);
            dgvPedidos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvPedidos.BorderStyle = BorderStyle.FixedSingle;

            // DataGridView de DetallePedido
            dgvDetallePedido.Top = dgvPedidos.Bottom + 18;
            dgvDetallePedido.Left = dgvPedidos.Left;
            dgvDetallePedido.Width = dgvPedidos.Width;
            dgvDetallePedido.Height = 180;
            dgvDetallePedido.BackgroundColor = Color.White;
            dgvDetallePedido.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDetallePedido.DefaultCellStyle.BackColor = Color.White;
            dgvDetallePedido.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 255);
            dgvDetallePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvDetallePedido.BorderStyle = BorderStyle.FixedSingle;
        }

        private void CargarPedidos(string estadoFiltro = "Todos")
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                StringBuilder query = new StringBuilder(@"
                    SELECT 
                        p.IdPedido, 
                        p.Fecha, 
                        ISNULL(m.NumeroMesa, 'Sin mesa') AS NumeroMesa, 
                        ep.NombreEstado, 
                        tc.NombreTipo
                    FROM Pedidos p
                    LEFT JOIN Mesas m ON p.IdMesa = m.IdMesa
                    INNER JOIN EstadoPedido ep ON p.IdEstadoPedido = ep.IdEstadoPedido
                    INNER JOIN TiposConsumo tc ON p.IdTipoConsumo = tc.IdTipoConsumo
                    WHERE 1 = 1
                ");

                if (estadoFiltro != "Todos")
                {
                    query.Append(" AND ep.NombreEstado = @estado ");

                    if (estadoFiltro == "Entregado")
                    {
                        query.Append(" AND CAST(p.Fecha AS DATE) = CAST(GETDATE() AS DATE) ");
                    }
                }

                SqlCommand cmd = new SqlCommand(query.ToString(), conn);

                if (estadoFiltro != "Todos")
                    cmd.Parameters.AddWithValue("@estado", estadoFiltro);

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

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvPedidos.Rows[e.RowIndex];
                    int idPedido = Convert.ToInt32(row.Cells["IdPedido"].Value);
                    CargarDetallePedido(idPedido);
                }
            }
            catch { }
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

        private bool HayTurnoAbierto()
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Turnos WHERE Estado = 'Abierto'", conn))
            {
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnPedidoNuevo_Click(object sender, EventArgs e)
        {
            if (!HayTurnoAbierto())
            {
                MessageBox.Show("No se puede realizar pedidos sin un turno abierto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            main.CargarFormulario(new NuevoPedidoForm(main));
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.CurrentRow != null)
            {
                int idPedido = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["IdPedido"].Value);
                EditarPedidoForm editarPedidoForm = new EditarPedidoForm(idPedido, main);
                main.CargarFormulario(new EditarPedidoForm(idPedido, main));
            }
            else
            {
                MessageBox.Show("Selecciona un pedido para editar.");
            }
        }
    }
}
