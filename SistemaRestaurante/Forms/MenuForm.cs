using SistemaRestaurante.Services;
using SistemaRestaurante.Utils;
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
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtCategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, escribe el nombre de la categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Deseas agregar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;


            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Categorias (Nombre) VALUES (@nombre)",conn);
                cmd.Parameters.AddWithValue("@nombre",txtCategoria.Text);
                cmd .ExecuteNonQuery();

                MessageBox.Show("Categoria agregada");
                txtCategoria.Clear();
                UtilidadesUI.CargarCategorias(cbCategoriaPadre, dgvCategorias);
            }

        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            UtilidadesUI.CargarCategorias(cbCategoriaPadre, dgvCategorias);
            UtilidadesUI.CargarSubcategorias(dgvSubCategorias);
        }

        private void btnAgregarSubcategoria_Click(object sender, EventArgs e)
        {
            string nombre = txtSubcategoria.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, escribe el nombre de la subcategoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCategoriaPadre.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecciona una categoría padre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Deseas agregar esta subcategoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Subcategorias (Nombre, IdCategoria) VALUES (@nombre, @idcategoria)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtSubcategoria.Text);
                cmd.Parameters.AddWithValue("@idcategoria", cbCategoriaPadre.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Subcategoría agregada");
                txtSubcategoria.Clear();
                UtilidadesUI.CargarSubcategorias(dgvSubCategorias);
            }
        }
    }
}
