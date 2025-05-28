using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class PlatosForm : Form
    {
        public PlatosForm()
        {
            InitializeComponent();
            this.Load += PlatosForm_Load;
            dgvPlatos.CellClick += dgvPlatos_CellClick;

        }
        private void CargarSubcategorias()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdSubcategoria, Nombre FROM Subcategorias", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbSubcategoria.DataSource = dt;
                cbSubcategoria.DisplayMember = "Nombre";
                cbSubcategoria.ValueMember = "IdSubcategoria";
            }
        }
        private void CargarPlatos(string filtroDisponibilidad = "Todos", string textoBusqueda = "")
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                StringBuilder query = new StringBuilder(@"
            SELECT p.IdPlato, p.Nombre, p.Precio, p.Descripcion,
                   p.Disponible, p.Imagen, s.Nombre AS Subcategoria
            FROM Platos p
            INNER JOIN Subcategorias s ON p.IdSubcategoria = s.IdSubcategoria
            WHERE 1 = 1 ");

                if (filtroDisponibilidad == "Solo disponibles")
                    query.Append(" AND p.Disponible = 1 ");
                else if (filtroDisponibilidad == "Solo no disponibles")
                    query.Append(" AND p.Disponible = 0 ");

                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                    query.Append(" AND p.Nombre LIKE @busqueda ");

                SqlCommand cmd = new SqlCommand(query.ToString(), conn);

                if (!string.IsNullOrWhiteSpace(textoBusqueda))
                    cmd.Parameters.AddWithValue("@busqueda", "%" + textoBusqueda + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPlatos.DataSource = dt;

                if (dgvPlatos.Columns.Contains("IdPlato"))
                    dgvPlatos.Columns["IdPlato"].Visible = false;

                if (dgvPlatos.Columns.Contains("Imagen"))
                    dgvPlatos.Columns["Imagen"].Visible = false;
            }
        }

        private void PlatosForm_Load(object sender, EventArgs e)
        {
            if (cbFiltroDisponibilidad.Items.Count == 0)
            {
                cbFiltroDisponibilidad.Items.Add("Todos");
                cbFiltroDisponibilidad.Items.Add("Solo disponibles");
                cbFiltroDisponibilidad.Items.Add("Solo no disponibles");
            }
            cbFiltroDisponibilidad.SelectedIndex = 1;
            CargarPlatos("Solo disponibles", "");

            CargarSubcategorias();
            dgvPlatos.ReadOnly = true;
            dgvPlatos.AllowUserToAddRows = false;
            dgvPlatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Platos (Nombre, Precio, Descripcion, Imagen, Disponible, IdSubcategoria) VALUES (@nombre, @precio, @desc, @imagen, @disp, @idSub)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombrePlato.Text);
                cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@imagen", pbImagen.Tag ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@disp", chkDisponible.Checked);
                cmd.Parameters.AddWithValue("@idSub", cbSubcategoria.SelectedValue);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Plato agregado");
                CargarPlatos("Solo disponibles", "");
                LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            txtPrecio.Clear();
            txtDescripcion.Clear();
            txtNombrePlato.Clear();
            chkDisponible.Checked = false;
            cbSubcategoria.SelectedIndex = -1;
            pbImagen.Image = null;
            pbImagen.Tag = null;

        }

        private void btnSeleccionarImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Imágenes|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string origen = ofd.FileName;
                string nombreArchivo = Path.GetFileName(origen);
                string destino = Path.Combine(Application.StartupPath, "Images", nombreArchivo);


                if (!File.Exists(destino))
                {
                    File.Copy(origen, destino);
                }

                pbImagen.ImageLocation = destino;
                pbImagen.Tag = "Images\\" + nombreArchivo;
            }
        }

        private void dgvPlatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPlatos.Rows[e.RowIndex];

                txtNombrePlato.Text = row.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                chkDisponible.Checked = Convert.ToBoolean(row.Cells["Disponible"].Value);
                cbSubcategoria.Text = row.Cells["Subcategoria"].Value.ToString();

                string ruta = row.Cells["Imagen"].Value?.ToString();
                if (!string.IsNullOrEmpty(ruta))
                {
                    string rutaCompleta = Path.Combine(Application.StartupPath, ruta);
                    if (File.Exists(rutaCompleta))
                        pbImagen.ImageLocation = rutaCompleta;
                    else
                        pbImagen.Image = null;
                }
                else
                {
                    pbImagen.Image = null;
                }
                pbImagen.Tag = ruta;

            }


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.SelectedRows.Count > 0)
            {
                //int idPlato = Convert.ToInt32(dgvPlatos.SelectedRows[0].Cells["IdPlato"].Value);
                int idPlato = Convert.ToInt32(dgvPlatos.CurrentRow.Cells["IdPlato"].Value);

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"UPDATE Platos 
                    SET Nombre = @nombre, Precio = @precio, Descripcion = @desc, 
                    Imagen = @imagen, Disponible = @disp, IdSubcategoria = @idSub 
                    WHERE IdPlato = @id", conn);

                    cmd.Parameters.AddWithValue("@nombre", txtNombrePlato.Text);
                    cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(txtPrecio.Text));
                    cmd.Parameters.AddWithValue("@desc", txtDescripcion.Text);
                    cmd.Parameters.AddWithValue("@imagen", pbImagen.Tag ?? (object)DBNull.Value);


                    cmd.Parameters.AddWithValue("@disp", chkDisponible.Checked);
                    cmd.Parameters.AddWithValue("@idSub", cbSubcategoria.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", idPlato);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Plato Actualizado");
                    CargarPlatos("Solo disponibles", "");
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un plato para editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPlatos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Eliminar este plato?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //int idPlato = Convert.ToInt32(dgvPlatos.SelectedRows[0].Cells["IdPlato"].Value);
                    int idPlato = Convert.ToInt32(dgvPlatos.CurrentRow.Cells["IdPlato"].Value);

                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Platos WHERE IdPlato = @id", conn);
                        cmd.Parameters.AddWithValue("@id", idPlato);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Plato eliminado correctamente");
                        CargarPlatos("Solo disponibles", "");
                        LimpiarCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un plato para eliminar.");
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = cbFiltroDisponibilidad.SelectedItem?.ToString() ?? "Todos";
            CargarPlatos(filtro, txtBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtro = cbFiltroDisponibilidad.SelectedItem?.ToString() ?? "Todos";
            string texto = txtBuscar.Text.Trim();
            CargarPlatos(filtro, texto);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cbFiltroDisponibilidad.SelectedIndex = 1;
            CargarPlatos("Solo disponibles", "");
            LimpiarCampos();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
