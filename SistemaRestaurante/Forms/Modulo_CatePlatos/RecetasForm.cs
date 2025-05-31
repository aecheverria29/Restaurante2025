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

namespace SistemaRestaurante.Forms.Modulo_CatePlatos
{
    public partial class RecetasForm : Form
    {
        private int? idPlatoInicial;
        public RecetasForm(int? idPlatoInicial)
        {
            InitializeComponent();
            this.Load += RecetasForm_Load;
            cbPlato.SelectedIndexChanged += cbPlato_SelectedIndexChanged;
            btnAgregar.Click += btnAgregar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnRegresar.Click += btnRegresar_Click;
            this.idPlatoInicial=idPlatoInicial;
        }

        private void RecetasForm_Load(object sender, EventArgs e)
        {
            CargarPlatos();
            CargarInsumos();
            if (idPlatoInicial != null)
            {
                cbPlato.SelectedValue = idPlatoInicial;
            }
            CargarReceta();
            PersonalizarEstilo();

        }
        private void CargarPlatos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdPlato, Nombre FROM Platos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbPlato.DataSource = dt;
                cbPlato.DisplayMember = "Nombre";
                cbPlato.ValueMember = "IdPlato";
            }
        }

        private void CargarInsumos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT IdInsumo, Nombre FROM Insumos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbInsumo.DataSource = dt;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "IdInsumo";
            }
        }

        private void CargarReceta()
        {
            if (cbPlato.SelectedValue == null || !(cbPlato.SelectedValue is int)) return;

            int idPlato = (int)cbPlato.SelectedValue;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT r.IdReceta, i.Nombre AS Insumo, r.CantidadNecesaria
            FROM Recetas r
            INNER JOIN Insumos i ON r.IdInsumo = i.IdInsumo
            WHERE r.IdPlato = @id", conn);
                cmd.Parameters.AddWithValue("@id", idPlato);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvReceta.DataSource = dt;

                if (dgvReceta.Columns.Contains("IdReceta"))
                    dgvReceta.Columns["IdReceta"].Visible = false;
            }
        }


        private void cbPlato_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReceta();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbPlato.SelectedValue == null || cbInsumo.SelectedValue == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            if (!decimal.TryParse(txtCantidad.Text, out decimal cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.");
                return;
            }

            int idPlato = Convert.ToInt32(cbPlato.SelectedValue);
            int idInsumo = Convert.ToInt32(cbInsumo.SelectedValue);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Recetas WHERE IdPlato = @plato AND IdInsumo = @insumo", conn);
                checkCmd.Parameters.AddWithValue("@plato", idPlato);
                checkCmd.Parameters.AddWithValue("@insumo", idInsumo);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("Este insumo ya está agregado a la receta.");
                    return;
                }

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Recetas (IdPlato, IdInsumo, CantidadNecesaria)
                    VALUES (@plato, @insumo, @cantidad)", conn);

                cmd.Parameters.AddWithValue("@plato", idPlato);
                cmd.Parameters.AddWithValue("@insumo", idInsumo);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Ingrediente agregado a la receta.");
                txtCantidad.Clear();
                CargarReceta();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReceta.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un ingrediente para eliminar.");
                return;
            }

            int idReceta = Convert.ToInt32(dgvReceta.CurrentRow.Cells["IdReceta"].Value);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Recetas WHERE IdReceta = @id", conn);
                cmd.Parameters.AddWithValue("@id", idReceta);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Ingrediente eliminado.");
                CargarReceta();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarPlato_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarPlato.Text.Trim();

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT IdPlato, Nombre 
            FROM Platos 
            WHERE Nombre LIKE @filtro", conn);

                cmd.Parameters.AddWithValue("@filtro", "%" + texto + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbPlato.DataSource = dt;
                cbPlato.DisplayMember = "Nombre";
                cbPlato.ValueMember = "IdPlato";
            }
        }

        private void PersonalizarEstilo()
        {
            // Fondo general
            this.BackColor = Color.FromArgb(246, 247, 251);

            // Fuente pequeña y elegante para labels
            float tamLabel = 8f;
            Label[] labels = { label1, label2, label3 }; // Agrega aquí todos tus labels
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", tamLabel, FontStyle.Regular);
                lbl.ForeColor = Color.FromArgb(44, 62, 80);
                lbl.AutoSize = true;
            }

            // TextBox
            txtBuscarPlato.Font = txtCantidad.Font = new Font("Segoe UI", 10F);
            txtBuscarPlato.BackColor = txtCantidad.BackColor = Color.White;

            // ComboBox
            cbPlato.Font = cbInsumo.Font = new Font("Segoe UI", 10F);

            // DataGridView
            dgvReceta.BackgroundColor = Color.White;
            dgvReceta.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F);
            dgvReceta.DefaultCellStyle.BackColor = Color.White;
            dgvReceta.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvReceta.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Botones principales
            Button[] btns = { btnAgregar, btnEliminar, btnRegresar };
            Color[] colors = {
        Color.FromArgb(39, 174, 96),     // Verde
        Color.FromArgb(192, 57, 43),     // Rojo
        Color.FromArgb(52, 152, 219)     // Azul
    };
            string[] texts = { "Agregar", "Eliminar", "Regresar" };

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
                btns[i].BackColor = colors[i];
                btns[i].ForeColor = Color.White;
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].FlatAppearance.BorderSize = 0;
                btns[i].Cursor = Cursors.Hand;
                btns[i].Width = 95;
                btns[i].Height = 36;
                btns[i].Text = texts[i];
                int idx = i; // Para evitar el closure bug
                btns[i].MouseEnter += (s, e) => btns[idx].BackColor = ControlPaint.Dark(colors[idx]);
                btns[i].MouseLeave += (s, e) => btns[idx].BackColor = colors[idx];
            }
        }

    }
}
