using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
            this.main = main;
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo general
            this.BackColor = Color.FromArgb(246, 247, 251);

            // -------- Labels --------
            Label[] labels = { label1, label2, label3, label4 };
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(44, 62, 80);
                lbl.AutoSize = true;
            }

            // -------- Textbox --------
            TextBox[] txts = { txtNombre, txtCantidad, txtUnidad, txtMinimo };
            int leftLbl = 80;
            int leftInput = 320;
            int topIni = 60, gapY = 58;
            int txtWidth = 220;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Top = topIni + i * gapY;
                labels[i].Left = leftLbl;
                txts[i].Top = labels[i].Top - 4;
                txts[i].Left = leftInput;
                txts[i].Width = txtWidth;
                txts[i].Font = new Font("Segoe UI", 13F);
                txts[i].BackColor = Color.White;
            }

            // -------- DataGridView y Título tabla --------
            label5.Text = "Lista de insumos";
            label5.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(49, 70, 194);
            label5.Left = leftInput + txtWidth + 120;
            label5.Top = topIni - 18;

            dgvInsumos.Top = label5.Bottom + 4;
            dgvInsumos.Left = label5.Left - 20;
            dgvInsumos.Width = 600;
            dgvInsumos.Height = 250;
            dgvInsumos.BackgroundColor = Color.White;
            dgvInsumos.DefaultCellStyle.Font = new Font("Segoe UI", 13F);
            dgvInsumos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);

            // -------- Botones principales (más abajo de los campos y de la tabla) --------
            Button[] btns = { btnAgregar, btnEditar, btnEliminar, btnLimpiar };
            string[] texts = { "Agregar insumo", "Editar insumo", "Eliminar insumo", "Limpiar campos" };
            Color[] colores = {
        Color.SeaGreen, Color.SteelBlue, Color.IndianRed, Color.Gray
    };
            int btnWidth = 220, btnHeight = 52, btnGap = 32;
            // El top de los botones será después del último textbox o después de la tabla, lo que sea más bajo
            int baseBtns = Math.Max(txtMinimo.Bottom, dgvInsumos.Bottom) + 32;
            int btnsLeft = leftLbl;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = btns[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = baseBtns;
                btn.Left = btnsLeft + i * (btnWidth + btnGap);
                btn.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
                btn.BackColor = colores[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.Text = texts[i];
                btn.BringToFront();
            }

            // -------- Botón regresar (abajo a la derecha) --------
            btnRegresar.Width = 170;
            btnRegresar.Height = 48;
            btnRegresar.Left = dgvInsumos.Left + dgvInsumos.Width - btnRegresar.Width;
            btnRegresar.Top = baseBtns;
            btnRegresar.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnRegresar.BackColor = Color.FromArgb(110, 116, 136);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.BringToFront();
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
            if (!decimal.TryParse(txtCantidad.Text, out cantidad) || !decimal.TryParse(txtMinimo.Text, out minimo))
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
                SELECT SCOPE_IDENTITY();", conn);

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@cant", cantidad);
                cmd.Parameters.AddWithValue("@unidad", txtUnidad.Text);
                cmd.Parameters.AddWithValue("@minimo", minimo);

                int idInsumo = Convert.ToInt32(cmd.ExecuteScalar());

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
