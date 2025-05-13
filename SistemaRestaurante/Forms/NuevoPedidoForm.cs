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
    public partial class NuevoPedidoForm : Form
    {
        public NuevoPedidoForm()
        {
            InitializeComponent();
            cbTipoConsumo.SelectedIndexChanged += cbTipoConsumo_SelectedIndexChanged;
            this.Load += NuevoPedidoForm_Load;

        }
        private void CargarCombos()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
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
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbTipoConsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = cbTipoConsumo.Text;

            if (tipo == "Cliente")
            {
                txtJustificacion.Text = "";
                txtJustificacion.Enabled = false;
            }
            else
            {
                txtJustificacion.Enabled = true;
            }
        }

        private void NuevoPedidoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            txtJustificacion.Enabled = false;
        }
        class PlatoPedidoTemp
        {
            public int IdPlato { get; set; }
            public string NombrePlato { get; set; }
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal Subtotal => PrecioUnitario * Cantidad;
            public string Comentario { get; set; }
        }
        
        List<PlatoPedidoTemp> listaDetalle = new List<PlatoPedidoTemp>();

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

            // Obtener precio del plato desde DataSource
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
            if (cbMesa.SelectedValue == null || cbTipoConsumo.SelectedValue == null || listaDetalle.Count == 0)
            {
                MessageBox.Show("Completa todos los datos y agrega al menos un plato.");
                return;
            }

            int idMesa = (int)cbMesa.SelectedValue;
            int idTipoConsumo = (int)cbTipoConsumo.SelectedValue;
            string justificacion = txtJustificacion.Enabled ? txtJustificacion.Text : null;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction transaccion = conn.BeginTransaction();

                try
                {
                    // 1. Insertar pedido
                    SqlCommand cmdInsertPedido = new SqlCommand(@"
                INSERT INTO Pedidos (Fecha, IdMesa, IdEstadoPedido, IdTipoConsumo, Justificacion)
                VALUES (GETDATE(), @mesa, 1, @tipo, @justif);
                SELECT SCOPE_IDENTITY();", conn, transaccion);

                    cmdInsertPedido.Parameters.AddWithValue("@mesa", idMesa);
                    cmdInsertPedido.Parameters.AddWithValue("@tipo", idTipoConsumo);
                    cmdInsertPedido.Parameters.AddWithValue("@justif", (object)justificacion ?? DBNull.Value);

                    int idPedido = Convert.ToInt32(cmdInsertPedido.ExecuteScalar());

                    // 2. Insertar detalle del pedido
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
                    }

                    // 3. Cambiar estado de la mesa a Ocupada (IdEstadoMesa = 2)
                    SqlCommand cmdMesa = new SqlCommand("UPDATE Mesas SET IdEstadoMesa = 2 WHERE IdMesa = @mesa", conn, transaccion);
                    cmdMesa.Parameters.AddWithValue("@mesa", idMesa);
                    cmdMesa.ExecuteNonQuery();

                    // 4. Confirmar todo
                    transaccion.Commit();

                    MessageBox.Show("Pedido registrado exitosamente.");
                    this.Close();
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
            this.Close();
        }
    }
}
