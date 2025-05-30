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
    public partial class UsuariosForm : Form
    {
        private MainForm main;
        public UsuariosForm(MainForm main)
        {
            InitializeComponent();
            this.Load += UsuariosForm_Load;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            this.main=main;
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
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
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
                    cmd.Parameters.AddWithValue("@nombre",txtNombre.Text);
                    cmd.Parameters.AddWithValue("@usuario",txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena",txtContrasena.Text);
                    cmd.Parameters.AddWithValue("@idrol", cbRoles.SelectedValue);
                    cmd.Parameters.AddWithValue("@id",idUsuario);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario Actualizado correctamente");
                    UtilidadesUI.CargarUsuarios(dgvUsuarios);

                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.");
            }
            txtNombre.Clear();
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

                    using(SqlConnection conn = DBConnection.GetConnection())
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
            txtNombre.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            cbRoles.SelectedIndex = -1;
        }
    }
}
