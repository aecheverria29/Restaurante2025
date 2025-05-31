using SistemaRestaurante.Services;
using SistemaRestaurante.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.Load += MenuForm_Load;
            this.Load += (s, e) => PersonalizarEstilo();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Categorias (Nombre) VALUES (@nombre)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtCategoria.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Categoría agregada");
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

        private void PersonalizarEstilo()
        {
            // Fondo moderno
            this.BackColor = Color.FromArgb(246, 247, 251);

            // ---- Título principal ----
            Label lblTitulo;
            if (this.Controls.ContainsKey("lblTitulo"))
                lblTitulo = (Label)this.Controls["lblTitulo"];
            else
            {
                lblTitulo = new Label();
                lblTitulo.Name = "lblTitulo";
                this.Controls.Add(lblTitulo);
            }
            lblTitulo.Text = "Gestión de Menú";
            lblTitulo.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(49, 70, 194);
            lblTitulo.AutoSize = true;
            lblTitulo.Left = 45;
            lblTitulo.Top = 20;

            // ---- Labels ----
            label1.Text = "Categoría";
            label2.Text = "Categoría Padre";
            label3.Text = "Subcategoría";

            label1.Font = label2.Font = label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = label2.ForeColor = label3.ForeColor = Color.FromArgb(44, 62, 80);
            label1.AutoSize = label2.AutoSize = label3.AutoSize = true;

            // Ubicación y ancho de controles superiores
            int yTop = lblTitulo.Bottom + 20;
            int xPad = 50;
            int yInputs = yTop + 22;

            // Label y entrada de categoría
            label1.Left = xPad;
            label1.Top = yTop;
            txtCategoria.Left = xPad;
            txtCategoria.Top = yInputs;
            txtCategoria.Width = 160;
            txtCategoria.Font = new Font("Segoe UI", 10);

            btnAgregarCategoria.Left = txtCategoria.Right + 14;
            btnAgregarCategoria.Top = txtCategoria.Top - 2;
            btnAgregarCategoria.Width = 130;
            btnAgregarCategoria.Height = 38;
            btnAgregarCategoria.Text = "Agregar";
            btnAgregarCategoria.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAgregarCategoria.BackColor = Color.FromArgb(39, 174, 96);
            btnAgregarCategoria.ForeColor = Color.White;
            btnAgregarCategoria.FlatStyle = FlatStyle.Flat;
            btnAgregarCategoria.FlatAppearance.BorderSize = 0;
            btnAgregarCategoria.Cursor = Cursors.Hand;
            btnAgregarCategoria.MouseEnter += (s, e) => btnAgregarCategoria.BackColor = ControlPaint.Dark(btnAgregarCategoria.BackColor);
            btnAgregarCategoria.MouseLeave += (s, e) => btnAgregarCategoria.BackColor = Color.FromArgb(39, 174, 96);

            // Label y combo de categoría padre
            label2.Left = btnAgregarCategoria.Right + 36;
            label2.Top = yTop;
            cbCategoriaPadre.Left = label2.Left;
            cbCategoriaPadre.Top = yInputs;
            cbCategoriaPadre.Width = 160;
            cbCategoriaPadre.Font = new Font("Segoe UI", 10);

            // Label y entrada de subcategoría
            label3.Left = cbCategoriaPadre.Right + 28;
            label3.Top = yTop;
            txtSubcategoria.Left = label3.Left;
            txtSubcategoria.Top = yInputs;
            txtSubcategoria.Width = 160;
            txtSubcategoria.Font = new Font("Segoe UI", 10);

            btnAgregarSubcategoria.Left = txtSubcategoria.Right + 14;
            btnAgregarSubcategoria.Top = txtSubcategoria.Top - 2;
            btnAgregarSubcategoria.Width = 130;
            btnAgregarSubcategoria.Height = 38;
            btnAgregarSubcategoria.Text = "Agregar";
            btnAgregarSubcategoria.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnAgregarSubcategoria.BackColor = Color.FromArgb(41, 128, 185);
            btnAgregarSubcategoria.ForeColor = Color.White;
            btnAgregarSubcategoria.FlatStyle = FlatStyle.Flat;
            btnAgregarSubcategoria.FlatAppearance.BorderSize = 0;
            btnAgregarSubcategoria.Cursor = Cursors.Hand;
            btnAgregarSubcategoria.MouseEnter += (s, e) => btnAgregarSubcategoria.BackColor = ControlPaint.Dark(btnAgregarSubcategoria.BackColor);
            btnAgregarSubcategoria.MouseLeave += (s, e) => btnAgregarSubcategoria.BackColor = Color.FromArgb(41, 128, 185);

            // ---- DataGridViews y títulos ----
            int tablasTop = txtCategoria.Bottom + 35;

            // Label Categorías
            Label lblTablaCat;
            if (this.Controls.ContainsKey("lblTablaCat"))
                lblTablaCat = (Label)this.Controls["lblTablaCat"];
            else
            {
                lblTablaCat = new Label();
                lblTablaCat.Name = "lblTablaCat";
                this.Controls.Add(lblTablaCat);
            }
            lblTablaCat.Text = "Categoría";
            lblTablaCat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTablaCat.Left = xPad + 5;
            lblTablaCat.Top = tablasTop - 28;

            dgvCategorias.Left = xPad;
            dgvCategorias.Top = tablasTop;
            dgvCategorias.Width = 310;
            dgvCategorias.Height = 245;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvCategorias.DefaultCellStyle.BackColor = Color.White;
            dgvCategorias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Label Subcategorías
            Label lblTablaSubCat;
            if (this.Controls.ContainsKey("lblTablaSubCat"))
                lblTablaSubCat = (Label)this.Controls["lblTablaSubCat"];
            else
            {
                lblTablaSubCat = new Label();
                lblTablaSubCat.Name = "lblTablaSubCat";
                this.Controls.Add(lblTablaSubCat);
            }
            lblTablaSubCat.Text = "Subcategoría";
            lblTablaSubCat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTablaSubCat.Left = dgvCategorias.Right + 70;
            lblTablaSubCat.Top = tablasTop - 28;

            dgvSubCategorias.Left = dgvCategorias.Right + 55;
            dgvSubCategorias.Top = tablasTop;
            dgvSubCategorias.Width = 350;
            dgvSubCategorias.Height = 245;
            dgvSubCategorias.BackgroundColor = Color.White;
            dgvSubCategorias.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvSubCategorias.DefaultCellStyle.BackColor = Color.White;
            dgvSubCategorias.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvSubCategorias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            dgvSubCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajuste del tamaño del formulario
            this.Width = dgvSubCategorias.Right + 70;
            this.Height = dgvCategorias.Bottom + 70;
        }

    }
}
