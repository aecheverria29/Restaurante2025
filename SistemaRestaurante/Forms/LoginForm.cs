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
using SistemaRestaurante.Services;
using SistemaRestaurante.Forms;
using SistemaRestaurante.Models;

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
                        /*SesionActual.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
                        SesionActual.Nombre = reader["Nombre"].ToString();
                        SesionActual.Usuario = reader["Usuario"].ToString();
                        SesionActual.IdRol = Convert.ToInt32(reader["IdRol"]);*/

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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
