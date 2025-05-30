using SistemaRestaurante.Services;
using SistemaRestaurante.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class UsuariosForm : Form
    {
        private MainForm main;
        public UsuariosForm(MainForm main)
        {
            InitializeComponent();
            this.Load += UsuariosForm_Load;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            this.main = main;

            // ---- ESTILO PERSONALIZADO WINFORMS ----
            PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            this.BackColor = Color.FromArgb(247, 247, 249);

            // Título
            label5.Font = new Font("Segoe UI Semibold", 20, FontStyle.Bold);
            label5.Text = "Gestión de Usuarios";
            label5.ForeColor = Color.FromArgb(49, 70, 194);
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Left = (this.ClientSize.Width - label5.Width) / 2;
            label5.Top = 24;

            // Labels
            foreach (var label in new[] { label1, label2, label3, label4 })
            {
                label.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(56, 62, 88);
            }

            // TextBox y ComboBox
            foreach (var input in new Control[] { txtNombree, txtUsuario, txtContrasena, cbRoles })
            {
                input.Font = new Font("Segoe UI", 12);
                input.Width = 200;
            }

            // Botones
            EstilizarBoton(btnAgregar, Color.SeaGreen);
            EstilizarBoton(btnEditar, Color.RoyalBlue);
            EstilizarBoton(btnEliminar, Color.IndianRed);

            // Espaciado vertical y alineación central
            int leftBase = 90, topBase = 80, espY = 48;
            label1.Left = leftBase;
            label1.Top = topBase;
            txtNombree.Left = leftBase + 110;
            txtNombree.Top = label1.Top - 2;

            label2.Left = leftBase;
            label2.Top = label1.Top + espY;
            txtUsuario.Left = txtNombree.Left;
            txtUsuario.Top = label2.Top - 2;

            label3.Left = leftBase;
            label3.Top = label2.Top + espY;
            txtContrasena.Left = txtNombree.Left;
            txtContrasena.Top = label3.Top - 2;

            label4.Left = leftBase;
            label4.Top = label3.Top + espY;
            cbRoles.Left = txtNombree.Left;
            cbRoles.Top = label4.Top - 2;

            // Botones alineados horizontalmente
            int btnY = label4.Top + espY + 18;
            btnAgregar.Top = btnEditar.Top = btnEliminar.Top = btnY;
            btnAgregar.Left = txtNombree.Left;
            btnEditar.Left = btnAgregar.Left + btnAgregar.Width + 10;
            btnEliminar.Left = btnEditar.Left + btnEditar.Width + 10;

            // DataGridView personalizado
            dgvUsuarios.Top = btnAgregar.Top + btnAgregar.Height + 32;
            dgvUsuarios.Left = leftBase;
            dgvUsuarios.Width = this.ClientSize.Width - leftBase * 2 - 20;
            dgvUsuarios.Height = 180;
            dgvUsuarios.BackgroundColor = Color.FromArgb(240, 241, 246);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(183, 209, 249);
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.BorderStyle = BorderStyle.FixedSingle;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void EstilizarBoton(Button btn, Color color)
        {
            btn.Font = new Font("Segoe UI Semibold", 11, FontStyle.Bold);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Width = 100;
            btn.Height = 35;
            btn.Cursor = Cursors.Hand;
        }

        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            UtilidadesUI.CargarRoles(cbRoles);
            UtilidadesUI.CargarUsuarios(dgvUsuarios);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarUsuarioForm agregarForm = new AgregarUsuarioForm(main);
            main.CargarFormulario(agregarForm);
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                txtNombree.Text = row.Cells["Nombre"].Value.ToString();
                txtUsuario.Text = row.Cells["Usuario"].Value.ToString();
                txtContrasena.Text = "";
                cbRoles.Text = row.Cells["NombreRol"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Usuarios SET Nombre = @nombre, Usuario = @usuario, Contrasena = @contrasena, IdRol = @idrol WHERE IdUsuario = @id", conn);
                    cmd.Parameters.AddWithValue("@nombre", txtNombree.Text);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);
                    cmd.Parameters.AddWithValue("@idrol", cbRoles.SelectedValue);
                    cmd.Parameters.AddWithValue("@id", idUsuario);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario Actualizado correctamente");
                    UtilidadesUI.CargarUsuarios(dgvUsuarios);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
            txtNombree.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cbRoles.SelectedIndex = -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

                    using (SqlConnection conn = DBConnection.GetConnection())
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Usuarios WHERE IdUsuario = @id", conn);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado correctamente");
                        UtilidadesUI.CargarUsuarios(dgvUsuarios);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un usuario para eliminar.");
            }
            txtNombree.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cbRoles.SelectedIndex = -1;
        }
    }
}
