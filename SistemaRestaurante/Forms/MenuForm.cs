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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.Load += MenuForm_Load;

        }
        private void CargarCategorias()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand  cmd = new SqlCommand("SELECT IdCategoria, Nombre FROM Categorias", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCategoriaPadre.DataSource = dt;
                cbCategoriaPadre.DisplayMember = "Nombre";
                cbCategoriaPadre.ValueMember = "IdCategoria";

                dgvCategorias.DataSource = dt;
            }
        }
        private void CargarSubcategorias()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT s.IdSubcategoria, s.Nombre, c.Nombre AS Categoria FROM Subcategorias s INNER JOIN Categorias c ON s.IdCategoria = c.IdCategoria", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubCategorias.DataSource = dt;
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Categorias (Nombre) VALUES (@nombre)",conn);
                cmd.Parameters.AddWithValue("@nombre",txtCategoria.Text);
                cmd .ExecuteNonQuery();

                MessageBox.Show("Categoria agregada");
                txtCategoria.Clear();
                CargarCategorias();
            }

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarSubcategorias();
        }

        private void btnAgregarSubcategoria_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Subcategorias (Nombre, IdCategoria) VALUES (@nombre, @idcategoria)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtSubcategoria.Text);
                cmd.Parameters.AddWithValue("@idcategoria", cbCategoriaPadre.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Subcategoría agregada");
                txtSubcategoria.Clear();
                CargarSubcategorias();
            }
        }
    }
}
