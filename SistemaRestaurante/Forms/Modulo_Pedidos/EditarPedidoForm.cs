using SistemaRestaurante.Models;
using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class EditarPedidoForm : Form
    {
        private int idPedido;
        private string estadoPedido;
        List<PlatoPedidoTemp> listaDetalle = new List<PlatoPedidoTemp>();
        private MainForm main;

        public EditarPedidoForm(int id, MainForm main)
        {
            InitializeComponent();
            idPedido = id;
            this.main = main;

            this.Load += EditarPedidoForm_Load;
            dgvDetalleTemp.ReadOnly = false;
            dgvDetalleTemp.CellEndEdit += dgvDetalleTemp_CellEndEdit;

            // Aplica estilos apenas cargue
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // -------- Fondo general --------
            this.BackColor = Color.FromArgb(246, 247, 251);

            // -------- Título arriba --------
            Label lblTitulo = new Label();
            lblTitulo.Text = "Editar Pedido";
            lblTitulo.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(49, 70, 194);
            lblTitulo.AutoSize = true;
            lblTitulo.Top = 28;
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblTitulo.Anchor = AnchorStyles.Top;
            this.Controls.Add(lblTitulo);

            // -------- Labels --------
            Label[] labels = { label2, label3, label7, label4, label5, label6 };
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(65, 68, 108);
            }

            // -------- Entradas --------
            Control[] entradas = { cbMesa, cbTipoConsumo, txtJustificacion, cbPlato, txtCantidadEdit, txtComentarioEdit };
            foreach (var ctrl in entradas)
            {
                ctrl.Font = new Font("Segoe UI", 11F);
                ctrl.Width = 180;
                ctrl.BackColor = Color.White;
            }

            // -------- Posiciona labels y cajas --------
            int leftLbl = 60, leftInput = 180, topIni = 90, gapY = 44;
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Top = topIni + i * gapY;
                labels[i].Left = leftLbl;
                entradas[i].Top = labels[i].Top - 3;
                entradas[i].Left = leftInput;
            }

            // -------- Botones --------
            Button[] botones = { btnAgregarPlato, btnEliminarPlato, btnCancelarPedido, btnActualizar, btnSalir };
            Color[] colores = {
                Color.SeaGreen, Color.IndianRed, Color.Gray, Color.RoyalBlue, Color.DarkSlateBlue
            };

            int btnWidth = 120, btnHeight = 38, btnGap = 18;
            int btnsTop = txtComentarioEdit.Bottom + 60;
            int btnsLeft = leftLbl;

            for (int i = 0; i < botones.Length; i++)
            {
                Button btn = botones[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = btnsTop;
                btn.Left = btnsLeft + i * (btnWidth + btnGap);
                btn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
                btn.BackColor = colores[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }

            // -------- DataGridView --------
            dgvDetalleTemp.Top = topIni;
            dgvDetalleTemp.Left = leftInput + 240;
            dgvDetalleTemp.Width = 420;
            dgvDetalleTemp.Height = 270;
            dgvDetalleTemp.BackgroundColor = Color.White;
            dgvDetalleTemp.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvDetalleTemp.DefaultCellStyle.BackColor = Color.White;
            dgvDetalleTemp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvDetalleTemp.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvDetalleTemp.BorderStyle = BorderStyle.FixedSingle;
        }

        // ---- (toda tu lógica original debajo, SIN CAMBIOS) ----

        private void EditarPedidoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatosPedido();
            CargarDetallePedido();
        }

        private void CargarCombos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                // Mesas
                SqlCommand cmdMesas = new SqlCommand("SELECT IdMesa, NumeroMesa FROM Mesas", conn);
                SqlDataAdapter daMesas = new SqlDataAdapter(cmdMesas);
                DataTable dtMesas = new DataTable();
                daMesas.Fill(dtMesas);
                cbMesa.DataSource = dtMesas;
                cbMesa.DisplayMember = "NumeroMesa";
                cbMesa.ValueMember = "IdMesa";

                // Tipos de consumo
                SqlCommand cmdTipos = new SqlCommand("SELECT IdTipoConsumo, NombreTipo FROM TiposConsumo", conn);
                SqlDataAdapter daTipos = new SqlDataAdapter(cmdTipos);
                DataTable dtTipos = new DataTable();
                daTipos.Fill(dtTipos);
                cbTipoConsumo.DataSource = dtTipos;
                cbTipoConsumo.DisplayMember = "NombreTipo";
                cbTipoConsumo.ValueMember = "IdTipoConsumo";

                // Platos
                SqlCommand cmdPlatos = new SqlCommand("SELECT IdPlato, Nombre, Precio FROM Platos WHERE Disponible = 1", conn);
                SqlDataAdapter daPlatos = new SqlDataAdapter(cmdPlatos);
                DataTable dtPlatos = new DataTable();
                daPlatos.Fill(dtPlatos);
                cbPlato.DataSource = dtPlatos;
                cbPlato.DisplayMember = "Nombre";
                cbPlato.ValueMember = "IdPlato";
            }
        }

        private void CargarDatosPedido()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT IdMesa, IdTipoConsumo, Justificacion, ep.NombreEstado
                    FROM Pedidos p
                    INNER JOIN EstadoPedido ep ON p.IdEstadoPedido = ep.IdEstadoPedido
                    WHERE IdPedido = @id", conn);

                cmd.Parameters.AddWithValue("@id", idPedido);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["IdMesa"] != DBNull.Value)
                        cbMesa.SelectedValue = Convert.ToInt32(reader["IdMesa"]);
                    else
                    {
                        cbMesa.SelectedIndex = -1;
                        cbMesa.Enabled = false;
                    }
                    //cbTipoConsumo.SelectedValue = Convert.ToInt32(reader["IdTipoConsumo"]);
                    estadoPedido = reader["NombreEstado"].ToString();
                    cbTipoConsumo.Enabled = false;
                    txtJustificacion.Text = reader["Justificacion"].ToString();
                }
            }
        }
        private void CargarDetallePedido()
        {
            listaDetalle.Clear();
            using (SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT dp.IdPlato, p.Nombre, dp.Cantidad, dp.PrecioUnitario, dp.Comentarios
                FROM DetallePedido dp
                INNER JOIN Platos p ON dp.IdPlato = p.IdPlato
                WHERE dp.IdPedido = @id", con);
                cmd.Parameters.AddWithValue("@id", idPedido);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listaDetalle.Add(new PlatoPedidoTemp
                    {
                        IdPlato = Convert.ToInt32(reader["IdPlato"]),
                        NombrePlato = reader["Nombre"].ToString(),
                        Cantidad = Convert.ToInt32(reader["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                        Comentario = reader["Comentarios"].ToString()
                    });
                }
                CargarDetalleTemporal();
            }
        }

        private void btnAgregarPlato_Click(object sender, EventArgs e)
        {
            if (cbPlato.SelectedValue == null || string.IsNullOrWhiteSpace(txtCantidadEdit.Text))
            {
                MessageBox.Show("Debes seleccionar un plato y una cantidad.");
                return;
            }

            int idPlato = (int)cbPlato.SelectedValue;
            string nombrePlato = cbPlato.Text;
            int cantidad;
            if (!int.TryParse(txtCantidadEdit.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad invalida");
                return;
            }
            decimal precio = Convert.ToDecimal(((DataRowView)cbPlato.SelectedItem)["Precio"]);
            string comentario = txtComentarioEdit.Text;

            var existente = listaDetalle.FirstOrDefault(p => p.IdPlato == idPlato);
            if (existente != null)
            {
                existente.Cantidad += cantidad;
                existente.Comentario = " | " + comentario;
            }
            else
            {
                listaDetalle.Add(new PlatoPedidoTemp
                {
                    IdPlato = idPlato,
                    NombrePlato = nombrePlato,
                    Cantidad = cantidad,
                    PrecioUnitario = precio,
                    Comentario = comentario
                });
            }
            CargarDetalleTemporal();
            txtCantidadEdit.Clear();
            txtComentarioEdit.Clear();
        }

        private void CargarDetalleTemporal()
        {
            dgvDetalleTemp.DataSource = null;
            dgvDetalleTemp.DataSource = listaDetalle;

            if (dgvDetalleTemp.Columns.Contains("IdPlato"))
                dgvDetalleTemp.Columns["IdPlato"].Visible = false;

            if (dgvDetalleTemp.Columns.Contains("Subtotal"))
                dgvDetalleTemp.Columns["Subtotal"].ReadOnly = true;

            if (dgvDetalleTemp.Columns.Contains("Cantidad"))
                dgvDetalleTemp.Columns["Cantidad"].ReadOnly = false;

            if (dgvDetalleTemp.Columns.Contains("Comentario"))
                dgvDetalleTemp.Columns["Comentario"].ReadOnly = false;
        }

        private void btnEliminarPlato_Click(object sender, EventArgs e)
        {
            if (dgvDetalleTemp.CurrentRow != null)
            {
                string nombre = dgvDetalleTemp.CurrentRow.Cells["NombrePlato"].Value.ToString();
                DialogResult r = MessageBox.Show($"¿Eliminar {nombre} del pedido?", "Confirmar", MessageBoxButtons.YesNo);

                if (r == DialogResult.Yes)
                {
                    int idPlato = Convert.ToInt32(dgvDetalleTemp.CurrentRow.Cells["IdPlato"].Value);
                    listaDetalle.RemoveAll(p => p.IdPlato == idPlato);
                    CargarDetalleTemporal();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un plato para eliminar.");
            }
        }

        private void dgvDetalleTemp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string col = dgvDetalleTemp.Columns[e.ColumnIndex].Name;

            if (col == "Cantidad" || col == "Comentario")
            {
                dgvDetalleTemp.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgvDetalleTemp.Refresh();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (estadoPedido == "Entregado" || estadoPedido == "Cancelado")
            {
                MessageBox.Show("No se puede editar un pedido que ya fue entregado.");
                return;
            }

            if (listaDetalle.Count == 0)
            {
                MessageBox.Show("Completa todos los datos y agrega al menos un plato.");
                return;
            }
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres actualizar el pedido?", "Confirmación", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                string justificacion = txtJustificacion.Enabled ? txtJustificacion.Text : null;

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlTransaction trans = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmdPedido = new SqlCommand(@"
                            UPDATE Pedidos
                            SET Justificacion = @justificacion
                            WHERE IdPedido = @id", conn, trans);

                        cmdPedido.Parameters.AddWithValue("@justificacion", (object)justificacion ?? DBNull.Value);
                        cmdPedido.Parameters.AddWithValue("@id", idPedido);
                        cmdPedido.ExecuteNonQuery();

                        SqlCommand cmdDelete = new SqlCommand("DELETE FROM DetallePedido WHERE IdPedido = @id", conn, trans);
                        cmdDelete.Parameters.AddWithValue("@id", idPedido);
                        cmdDelete.ExecuteNonQuery();

                        foreach (var plato in listaDetalle)
                        {
                            SqlCommand cmdInsert = new SqlCommand(@"
                                INSERT INTO DetallePedido (IdPedido, IdPlato, Cantidad, PrecioUnitario, Subtotal, Comentarios)
                                VALUES (@pedido, @plato, @cant, @precio, @sub, @coment)", conn, trans);

                            cmdInsert.Parameters.AddWithValue("@pedido", idPedido);
                            cmdInsert.Parameters.AddWithValue("@plato", plato.IdPlato);
                            cmdInsert.Parameters.AddWithValue("@cant", plato.Cantidad);
                            cmdInsert.Parameters.AddWithValue("@precio", plato.PrecioUnitario);
                            cmdInsert.Parameters.AddWithValue("@sub", plato.Subtotal);
                            cmdInsert.Parameters.AddWithValue("@coment", (object)plato.Comentario ?? DBNull.Value);
                            cmdInsert.ExecuteNonQuery();
                        }

                        trans.Commit();
                        MessageBox.Show("Pedido actualizado correctamente.");
                        main.CargarFormulario(new PedidosForm(main));
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        MessageBox.Show("Error al guardar los cambios: " + ex.Message);
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnCancelarPedido_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Estás seguro de cancelar este pedido?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                SqlCommand cmdEstado = new SqlCommand("SELECT IdEstadoPedido FROM Pedidos WHERE IdPedido = @id", conn);
                cmdEstado.Parameters.AddWithValue("@id", idPedido);
                int estado = Convert.ToInt32(cmdEstado.ExecuteScalar());

                if (estado >= 3) // 3 = Entregado, 4 = Cancelado
                {
                    MessageBox.Show("No se puede cancelar un pedido que ya fue entregado o cancelado.");
                    return;
                }

                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdCancelar = new SqlCommand(
                        "UPDATE Pedidos SET IdEstadoPedido = 4 WHERE IdPedido = @id", conn, trans);
                    cmdCancelar.Parameters.AddWithValue("@id", idPedido);
                    cmdCancelar.ExecuteNonQuery();

                    SqlCommand cmdMesa = new SqlCommand(
                        "UPDATE Mesas SET IdEstadoMesa = 1 WHERE IdMesa = (SELECT IdMesa FROM Pedidos WHERE IdPedido = @id)", conn, trans);
                    cmdMesa.Parameters.AddWithValue("@id", idPedido);
                    cmdMesa.ExecuteNonQuery();

                    trans.Commit();
                    MessageBox.Show("Pedido cancelado correctamente.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al cancelar el pedido: " + ex.Message);
                }
            }
            main.CargarFormulario(new PedidosForm(main));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new PedidosForm(main));
        }
    }
}
