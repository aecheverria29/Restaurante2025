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

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class InsumosForm : Form
    {
        private MainForm main;
        public InsumosForm(MainForm main)
        {
            InitializeComponent();
            this.Load += InsumosForm_Load;
            dgvInsumos.CellClick += dgvInsumos_CellClick;
            this.main=main;
        }

        private void InsumosForm_Load(object sender, EventArgs e)
        {
            CargarInsumos();
            dgvInsumos.AllowUserToAddRows = false;
            dgvInsumos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void CargarInsumos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Insumos", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvInsumos.DataSource = dt;
                dgvInsumos.Columns["IdInsumo"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtUnidad.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            decimal cantidad, minimo;
            if (!decimal.TryParse(txtCantidad.Text, out cantidad) || !decimal.TryParse(txtMinimo.Text,out minimo))
            {
                MessageBox.Show("Cantidad y stock mínimo deben ser números válidos.");
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Insumos (Nombre, Cantidad, Unidad, MinimoStock)
                VALUES (@nombre, @cant, @unidad, @minimo);
                SELECT SCOPE_IDENTITY();", conn); // ← Devuelve el ID generado

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@unidad", txtUnidad.Text);
                cmd.Parameters.AddWithValue("@minimo", minimo);

                // Ahora obtenemos el ID generado correctamente
                int idInsumo = Convert.ToInt32(cmd.ExecuteScalar());

                // Registrar movimiento de entrada
                SqlCommand movimientoCmd = new SqlCommand(@"
                INSERT INTO MovimientoInventario (IdInsumo, Fecha, TipoMovimiento, Cantidad, Justificacion)
                VALUES (@idInsumo, GETDATE(), 'Entrada', @cantidad, 'Stock inicial')", conn);

                movimientoCmd.Parameters.AddWithValue("@idInsumo", idInsumo);
                movimientoCmd.Parameters.AddWithValue("@cantidad", cantidad);
                movimientoCmd.ExecuteNonQuery();

                MessageBox.Show("Insumo agregado.");
                LimpiarCampos();
                CargarInsumos();
            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un insumo para editar.");
                return;
            }
            int id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["IdInsumo"].Value);
            decimal cantidad, minimo;
            if (!decimal.TryParse(txtCantidad.Text, out cantidad) || !decimal.TryParse(txtMinimo.Text, out minimo))
            {
                MessageBox.Show("Cantidad y stock mínimo deben ser números válidos.");
                return;
            }
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Insumos SET 
                    Nombre = @nombre, Cantidad = @cant, Unidad = @unidad, MinimoStock = @minimo 
                    WHERE IdInsumo = @id", conn);

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@unidad", txtUnidad.Text);
                cmd.Parameters.AddWithValue("@minimo", minimo);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insumo actualizado.");
                LimpiarCampos();
                CargarInsumos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvInsumos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un insumo para eliminar.");
                return;
            }
            DialogResult result = MessageBox.Show("¿Eliminar este insumo?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvInsumos.CurrentRow.Cells["IdInsumo"].Value);
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Insumos WHERE IdInsumo = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insumo eliminado.");
                    LimpiarCampos();
                    CargarInsumos();
                }
            }
        }

        private void dgvInsumos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvInsumos.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtCantidad.Text = row.Cells["Cantidad"].Value.ToString();
                txtUnidad.Text = row.Cells["Unidad"].Value.ToString();
                txtMinimo.Text = row.Cells["MinimoStock"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCantidad.Clear();
            txtUnidad.Clear();
            txtMinimo.Clear();
            dgvInsumos.ClearSelection();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new InventarioForm(main));
        }
    }
}
