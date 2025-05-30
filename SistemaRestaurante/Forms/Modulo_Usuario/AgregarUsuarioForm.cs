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
using SistemaRestaurante.Utils;


namespace SistemaRestaurante.Forms
{
    public partial class AgregarUsuarioForm : Form
    {
        private MainForm main;
        public AgregarUsuarioForm(MainForm mainForm)
        {
            InitializeComponent();
            this.Load += AgregarUsuarioForm_Load;
            main=mainForm;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuarios (Nombre, Usuario, Contrasena, IdRol) VALUES (@nombre, @usuario, @contrasena, @idrol)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);
                cmd.Parameters.AddWithValue("@idrol", cbRoles.SelectedValue);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuario agregado");
            }
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cbRoles.SelectedIndex = -1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que quieres cancelar?", "Confirmación", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                main.CargarFormulario(new UsuariosForm(main));
            }
            else
            {
                this.Close();
            }
            
        }

        private void AgregarUsuarioForm_Load(object sender, EventArgs e)
        {
            UtilidadesUI.CargarRoles(cbRoles);
        }
    }
}
