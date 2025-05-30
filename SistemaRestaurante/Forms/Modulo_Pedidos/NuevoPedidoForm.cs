using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Forms
{
    public partial class NuevoPedidoForm : Form
    {
        private MainForm main;
        List<PlatoPedidoTemp> listaDetalle = new List<PlatoPedidoTemp>();

        public NuevoPedidoForm(MainForm mainForm)
        {
            InitializeComponent();
            cbTipoConsumo.SelectedIndexChanged += cbTipoConsumo_SelectedIndexChanged;
            this.Load += NuevoPedidoForm_Load;
            main = mainForm;

            // Aplica el diseño al cargar
            this.Load += (s, e) => EstilizarFormulario();
        }

        private void EstilizarFormulario()
        {
            // Fondo del form
            this.BackColor = Color.FromArgb(247, 249, 252);

            // Título grande y centrado
            label1.Text = "Nuevo Pedido";
            label1.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(60, 70, 207);
            label1.AutoSize = true;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = 28;

            // Estilo para los labels
            Font labelFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            Color labelColor = Color.FromArgb(40, 40, 40);
            Label[] labels = { label2, label3, label7, label4, label5, label6 };
            foreach (var lbl in labels)
            {
                lbl.Font = labelFont;
                lbl.ForeColor = labelColor;
            }

            // Ajustar posiciones (puedes ajustar los valores si lo deseas más pegado o más separado)
            int leftLabels = 65, topBase = 90, spaceY = 46, anchoLabel = 140, anchoInput = 220, anchoCombo = 210;
            int currTop = topBase;

            // Tipo de Consumo
            label3.Left = leftLabels; label3.Top = currTop;
            cbTipoConsumo.Left = label3.Right + 12; cbTipoConsumo.Top = label3.Top - 2;
            cbTipoConsumo.Width = anchoCombo; cbTipoConsumo.Font = new Font("Segoe UI", 11F);
            cbTipoConsumo.DropDownStyle = ComboBoxStyle.DropDownList;

            // Mesa
            currTop += spaceY;
            label2.Left = leftLabels; label2.Top = currTop;
            cbMesa.Left = label2.Right + 12; cbMesa.Top = label2.Top - 2;
            cbMesa.Width = anchoCombo; cbMesa.Font = new Font("Segoe UI", 11F);

            // Justificación
            currTop += spaceY;
            label7.Left = leftLabels; label7.Top = currTop;
            txtJustificacion.Left = label7.Right + 12; txtJustificacion.Top = label7.Top - 2;
            txtJustificacion.Width = anchoInput; txtJustificacion.Font = new Font("Segoe UI", 11F);

            // Plato
            currTop += spaceY;
            label4.Left = leftLabels; label4.Top = currTop;
            cbPlato.Left = label4.Right + 12; cbPlato.Top = label4.Top - 2;
            cbPlato.Width = anchoCombo; cbPlato.Font = new Font("Segoe UI", 11F);

            // Botón Agregar Plato a la derecha del combo
            btnAgregarPlato.Left = cbPlato.Right + 12; btnAgregarPlato.Top = cbPlato.Top - 2;
            btnAgregarPlato.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAgregarPlato.BackColor = Color.SeaGreen;
            btnAgregarPlato.ForeColor = Color.White;
            btnAgregarPlato.FlatStyle = FlatStyle.Flat;
            btnAgregarPlato.FlatAppearance.BorderSize = 0;
            btnAgregarPlato.Width = 130;
            btnAgregarPlato.Height = 35;
            btnAgregarPlato.Text = "Agregar plato";
            btnAgregarPlato.Cursor = Cursors.Hand;

            // Cantidad
            currTop += spaceY;
            label5.Left = leftLabels; label5.Top = currTop;
            txtCantidad.Left = label5.Right + 12; txtCantidad.Top = label5.Top - 2;
            txtCantidad.Width = 90; txtCantidad.Font = new Font("Segoe UI", 11F);

            // Comentario
            currTop += spaceY;
            label6.Left = leftLabels; label6.Top = currTop;
            txtComentario.Left = label6.Right + 12; txtComentario.Top = label6.Top - 2;
            txtComentario.Width = 410; txtComentario.Font = new Font("Segoe UI", 11F);

            // DataGridView
            dgvDetalleTemp.Top = label6.Top + 44;
            dgvDetalleTemp.Left = leftLabels;
            dgvDetalleTemp.Width = 660;
            dgvDetalleTemp.Height = 170;
            dgvDetalleTemp.BackgroundColor = Color.White;
            dgvDetalleTemp.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvDetalleTemp.DefaultCellStyle.BackColor = Color.White;
            dgvDetalleTemp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(215, 230, 255);
            dgvDetalleTemp.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgvDetalleTemp.BorderStyle = BorderStyle.FixedSingle;

            // Botones guardar/cancelar
            int baseBtnsTop = dgvDetalleTemp.Bottom + 24;
            btnGuardarPedido.Left = label6.Left + 70; btnGuardarPedido.Top = baseBtnsTop;
            btnGuardarPedido.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGuardarPedido.Width = 140; btnGuardarPedido.Height = 40;
            btnGuardarPedido.BackColor = Color.FromArgb(72, 175, 90);
            btnGuardarPedido.ForeColor = Color.White;
            btnGuardarPedido.FlatStyle = FlatStyle.Flat;
            btnGuardarPedido.FlatAppearance.BorderSize = 0;
            btnGuardarPedido.Text = "Guardar pedido";
            btnGuardarPedido.Cursor = Cursors.Hand;

            btnCancelar.Left = btnGuardarPedido.Right + 30; btnCancelar.Top = baseBtnsTop;
            btnCancelar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancelar.Width = 140; btnCancelar.Height = 40;
            btnCancelar.BackColor = Color.FromArgb(213, 89, 89);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.Cursor = Cursors.Hand;
        }

        private void CargarCombos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                //Cargar mesas disponibles
                SqlCommand cmdMesas = new SqlCommand("SELECT IdMesa,NumeroMesa FROM Mesas WHERE IdEstadoMesa = 1", conn);
                SqlDataAdapter daMesas = new SqlDataAdapter(cmdMesas);
                DataTable dtMesas = new DataTable();
                daMesas.Fill(dtMesas);
                cbMesa.DataSource = dtMesas;
                cbMesa.DisplayMember = "NumeroMesa";
                cbMesa.ValueMember = "IdMesa";

                SqlCommand cmdTipos = new SqlCommand("SELECT IdTipoConsumo, NombreTipo FROM TiposConsumo", conn);
                SqlDataAdapter daTipos = new SqlDataAdapter(cmdTipos);
                DataTable dtTipos = new DataTable();
                daTipos.Fill(dtTipos);
                cbTipoConsumo.DataSource = dtTipos;
                cbTipoConsumo.DisplayMember = "NombreTipo";
                cbTipoConsumo.ValueMember = "IdTipoConsumo";

                // Cargar platos
                SqlCommand cmdPlatos = new SqlCommand("SELECT IdPlato, Nombre, Precio FROM Platos WHERE Disponible = 1", conn);
                SqlDataAdapter daPlatos = new SqlDataAdapter(cmdPlatos);
                DataTable dtPlatos = new DataTable();
                daPlatos.Fill(dtPlatos);
                cbPlato.DataSource = dtPlatos;
                cbPlato.DisplayMember = "Nombre";
                cbPlato.ValueMember = "IdPlato";
            }
        }

        private void label5_Click(object sender, EventArgs e) { }

        private void cbTipoConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cbTipoConsumo.Text;
            if (tipo == "Cliente" || tipo == "Para llevar")
            {
                txtJustificacion.Text = "";
                txtJustificacion.Enabled = false;
            }
            else
            {
                txtJustificacion.Enabled = true;
            }
            if (cbTipoConsumo.SelectedItem is DataRowView tipoRow)
            {
                int idTipoConsumo = Convert.ToInt32(tipoRow["IdTipoConsumo"]);
                if (idTipoConsumo != 1)
                {
                    cbMesa.Enabled = false;
                    cbMesa.SelectedIndex = -1;
                }
                else
                {
                    cbMesa.Enabled = true;
                }
            }
        }
        private void NuevoPedidoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            txtJustificacion.Enabled = false;
        }
        private void btnAgregarPlato_Click(object sender, EventArgs e)
        {
            if (cbPlato.SelectedValue == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Completa todos los campos antes de agregar.");
                return;
            }
            int idPlato = (int)cbPlato.SelectedValue;
            string nombre = cbPlato.Text;
            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            DataRowView selectedRow = (DataRowView)cbPlato.SelectedItem;
            decimal precio = Convert.ToDecimal(selectedRow["Precio"]);

            string comentario = txtComentario.Text;

            listaDetalle.Add(new PlatoPedidoTemp
            {
                IdPlato = idPlato,
                NombrePlato = nombre,
                PrecioUnitario = precio,
                Cantidad = cantidad,
                Comentario = comentario
            });

            CargarDetalleTemporal();
            txtCantidad.Clear();
            txtComentario.Clear();
        }

        private void CargarDetalleTemporal()
        {
            dgvDetalleTemp.DataSource = null;
            dgvDetalleTemp.DataSource = listaDetalle.Select(p => new
            {
                p.NombrePlato,
                p.Cantidad,
                p.PrecioUnitario,
                p.Subtotal,
                p.Comentario
            }).ToList();
        }

        private void btnGuardarPedido_Click(object sender, EventArgs e)
        {
            if (cbTipoConsumo.SelectedValue == null || listaDetalle.Count == 0)
            {
                MessageBox.Show("Completa todos los datos y agrega al menos un plato.");
                return;
            }

            int idTipoConsumo = (int)cbTipoConsumo.SelectedValue;
            int? idMesa = null;

            if (idTipoConsumo == 1)
            {
                if (cbMesa.SelectedValue == null)
                {
                    MessageBox.Show("Debes seleccionar una mesa.");
                    return;
                }
                idMesa = (int)cbMesa.SelectedValue;
            }

            string justificacion = txtJustificacion.Enabled ? txtJustificacion.Text : null;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {

                    SqlCommand cmdInsertPedido = new SqlCommand(@"
                    INSERT INTO Pedidos (Fecha, IdMesa, IdEstadoPedido, IdTipoConsumo, Justificacion)
                    VALUES (GETDATE(), @mesa, 1, @tipo, @justif);
                    SELECT SCOPE_IDENTITY();", conn, transaccion);

                    if (idMesa.HasValue)
                        cmdInsertPedido.Parameters.AddWithValue("@mesa", idMesa.Value);
                    else
                        cmdInsertPedido.Parameters.AddWithValue("@mesa", DBNull.Value);
                    cmdInsertPedido.Parameters.AddWithValue("@tipo", idTipoConsumo);
                    cmdInsertPedido.Parameters.AddWithValue("@justif", (object)justificacion ?? DBNull.Value);

                    int idPedido = Convert.ToInt32(cmdInsertPedido.ExecuteScalar());

                    foreach (var item in listaDetalle)
                    {
                        SqlCommand cmdDetalle = new SqlCommand(@"
                        INSERT INTO DetallePedido (IdPedido, IdPlato, Cantidad, PrecioUnitario, Subtotal, Comentarios)
                        VALUES (@pedido, @plato, @cant, @precio, @sub, @coment)", conn, transaccion);

                        cmdDetalle.Parameters.AddWithValue("@pedido", idPedido);
                        cmdDetalle.Parameters.AddWithValue("@plato", item.IdPlato);
                        cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@sub", item.Subtotal);
                        cmdDetalle.Parameters.AddWithValue("@coment", (object)item.Comentario ?? DBNull.Value);

                        cmdDetalle.ExecuteNonQuery();

                        // DESCONTAR INSUMOS SEGÚN RECETA
                        SqlCommand cmdReceta = new SqlCommand(@"
                            SELECT IdInsumo, CantidadNecesaria
                            FROM Recetas
                            WHERE IdPlato = @plato", conn, transaccion);
                        cmdReceta.Parameters.AddWithValue("@plato", item.IdPlato);

                        SqlDataAdapter da = new SqlDataAdapter(cmdReceta);
                        DataTable dtReceta = new DataTable();
                        da.Fill(dtReceta);

                        foreach (DataRow row in dtReceta.Rows)
                        {
                            int idInsumo = Convert.ToInt32(row["IdInsumo"]);
                            decimal cantidadPorPlato = Convert.ToDecimal(row["CantidadNecesaria"]);
                            decimal totalUsado = cantidadPorPlato * item.Cantidad;

                            SqlCommand cmdDescontar = new SqlCommand(@"
                                INSERT INTO MovimientoInventario (IdInsumo, Fecha, TipoMovimiento, Cantidad, Justificacion)
                                VALUES (@idInsumo, GETDATE(), 'Salida', @cantidad, @justif)", conn, transaccion);

                            cmdDescontar.Parameters.AddWithValue("@idInsumo", idInsumo);
                            cmdDescontar.Parameters.AddWithValue("@cantidad", totalUsado);
                            cmdDescontar.Parameters.AddWithValue("@justif", $"Uso en pedido #{idPedido} - {item.NombrePlato}");

                            cmdDescontar.ExecuteNonQuery();
                        }
                    }

                    if (idMesa.HasValue)
                    {
                        SqlCommand cmdMesa = new SqlCommand("UPDATE Mesas SET IdEstadoMesa = 2 WHERE IdMesa = @mesa", conn, transaccion);
                        cmdMesa.Parameters.AddWithValue("@mesa", idMesa.Value);
                        cmdMesa.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    MessageBox.Show("Pedido registrado exitosamente.");
                    main.CargarFormulario(new PedidosForm(main));
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    MessageBox.Show("Error al guardar el pedido: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cancelar?", "Confirmación", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                main.CargarFormulario(new PedidosForm(main));
            }
            else
            {
                this.Close();
            }
        }
    }
}
