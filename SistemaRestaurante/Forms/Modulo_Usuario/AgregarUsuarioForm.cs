using SistemaRestaurante.Services;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SistemaRestaurante.Utils;

namespace SistemaRestaurante.Forms
{
    public partial class AgregarUsuarioForm : Form
    {
        private MainForm main;

        public AgregarUsuarioForm(MainForm mainForm)
        {
            InitializeComponent();
            main = mainForm;
            this.Load += AgregarUsuarioForm_Load;
            this.Load += (s, e) => CenterFormControls();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                cbRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nombre, Usuario, Contrasena, IdRol) VALUES (@nombre, @usuario, @contrasena, @idrol)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text.Trim());
                cmd.Parameters.AddWithValue("@idrol", cbRoles.SelectedValue);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Usuario agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            main.CargarFormulario(new UsuariosForm(main));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar? Los datos no guardados se perderán.", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
                main.CargarFormulario(new UsuariosForm(main));
        }

        private void AgregarUsuarioForm_Load(object sender, EventArgs e)
        {
            UtilidadesUI.CargarRoles(cbRoles);
            cbRoles.SelectedIndex = -1;

            // Personaliza el título
            label5.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(68, 70, 160);

            // Centra el título horizontalmente respecto al formulario
            label5.Left = (this.ClientSize.Width - label5.Width) / 2;
            label5.Top = 45;

            // Define los controles
            Label[] labels = { lblNombre, lblUsuario, lblContrasena, lblRol };
            Control[] inputs = { txtNombre, txtUsuario, txtContrasena, cbRoles };

            // Fuente y color para los labels
            foreach (Label lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 13);
                lbl.ForeColor = Color.FromArgb(60, 60, 80);
            }

            // Inputs más grandes y limpios
            foreach (Control input in inputs)
            {
                input.Font = new Font("Segoe UI", 13);
                input.Width = 260;
            }

            // Posicionamiento vertical
            int firstTop = label5.Bottom + 36;
            int leftLabel = this.ClientSize.Width / 2 - 180;
            int leftInput = this.ClientSize.Width / 2 - 20;
            int heightStep = 54;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Top = firstTop + i * heightStep;
                labels[i].Left = leftLabel;
                inputs[i].Top = labels[i].Top - 3;
                inputs[i].Left = leftInput;
            }

            // Botones
            int btnWidth = 150, btnHeight = 38, spaceBtn = 20;
            btnAgregar.Width = btnWidth;
            btnCancelar.Width = btnWidth;
            btnAgregar.Height = btnHeight;
            btnCancelar.Height = btnHeight;

            btnAgregar.Top = cbRoles.Bottom + 36;
            btnAgregar.Left = this.ClientSize.Width / 2 - btnWidth - spaceBtn / 2;
            btnAgregar.BackColor = Color.SeaGreen;
            btnAgregar.ForeColor = Color.White;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            btnCancelar.Top = btnAgregar.Top;
            btnCancelar.Left = this.ClientSize.Width / 2 + spaceBtn / 2;
            btnCancelar.BackColor = Color.IndianRed;
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cbRoles.SelectedIndex = -1;
        }

        private void CenterFormControls()
        {
            // Centra el formulario y los controles
            int centerX = this.ClientSize.Width / 2;
            int top = 60;

            // Centra el título
            label5.Left = centerX - label5.Width / 2;

            // Labels y TextBox
            Label[] labels = { lblNombre, lblUsuario, lblContrasena, lblRol };
            Control[] inputs = { txtNombre, txtUsuario, txtContrasena, cbRoles };

            int labelWidth = 110;
            int textWidth = 220;
            int spaceY = 18;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Top = top + i * (38 + spaceY);
                labels[i].Left = centerX - textWidth / 2 - labelWidth + 5;
                inputs[i].Top = labels[i].Top - 2;
                inputs[i].Width = textWidth;
                inputs[i].Left = centerX - textWidth / 2 + 5;
            }

            // Botones
            btnAgregar.Width = 120;
            btnCancelar.Width = 120;
            btnAgregar.Top = cbRoles.Bottom + 36;
            btnCancelar.Top = btnAgregar.Bottom + 12;
            btnAgregar.Left = centerX - btnAgregar.Width / 2;
            btnCancelar.Left = centerX - btnCancelar.Width / 2;
        }
    }
}
