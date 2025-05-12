using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms;
using SistemaRestaurante.Services;
using SistemaRestaurante.Forms;

namespace SistemaRestaurante
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena", conn);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Bienvenido");
                        this.Hide();
                        MainForm main = new MainForm();
                        main.FormClosed += (s, args) => this.Show();

                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales Incorrectas");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: "+ex.Message);
                }
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
