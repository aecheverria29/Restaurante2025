using SistemaRestaurante.Models;
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
            this.Load += EditarPedidoForm_Load;
            dgvDetalleTemp.ReadOnly = false;
            dgvDetalleTemp.CellEndEdit += dgvDetalleTemp_CellEndEdit;
            this.main=main;
        }

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

                // Mesas (puedes mostrarlas todas o bloquear el combo luego)
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

                // Platos disponibles para agregar nuevos
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
            using(SqlConnection conn = DBConnection.GetConnection())
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
                    {
                        cbMesa.SelectedValue = Convert.ToInt32(reader["IdMesa"]);
                    }
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
            using(SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"SELECT dp.IdPlato, p.Nombre, dp.Cantidad, dp.PrecioUnitario, dp.Comentarios
                FROM DetallePedido dp
                INNER JOIN Platos p ON dp.IdPlato = p.IdPlato
                WHERE dp.IdPedido = @id", con);
                cmd.Parameters.AddWithValue("@id",idPedido);
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
            if (!int.TryParse(txtCantidadEdit.Text, out cantidad) || cantidad <=0)
            {
                MessageBox.Show("Cantidad invalida");
                return;
            }
            decimal precio = Convert.ToDecimal(((DataRowView)cbPlato.SelectedItem)["Precio"]);
            string comentario = txtComentarioEdit.Text;

            var existente = listaDetalle.FirstOrDefault(p => p.IdPlato == idPlato);
            if(existente != null)
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
            if(dgvDetalleTemp.CurrentRow != null)
            {
                string nombre = dgvDetalleTemp.CurrentRow.Cells["NombrePlato"].Value.ToString();
                DialogResult r = MessageBox.Show($"¿Eliminar {nombre} del pedido?", "Confirmar", MessageBoxButtons.YesNo);
            
                if(r== DialogResult.Yes)
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
            if (estadoPedido == "Entregado")
            {
                MessageBox.Show("No se puede editar un pedido que ya fue entregado.");
                return;
            }

            if (listaDetalle.Count == 0)
            {
                MessageBox.Show("Completa todos los datos y agrega al menos un plato.");
                return;
            }

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

                // Validar estado actual del pedido
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
                    // 1. Cambiar estado del pedido a Cancelado (IdEstadoPedido = 4)
                    SqlCommand cmdCancelar = new SqlCommand(
                        "UPDATE Pedidos SET IdEstadoPedido = 4 WHERE IdPedido = @id", conn, trans);
                    cmdCancelar.Parameters.AddWithValue("@id", idPedido);
                    cmdCancelar.ExecuteNonQuery();

                    // 2. Cambiar estado de la mesa a Disponible (IdEstadoMesa = 1)
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
