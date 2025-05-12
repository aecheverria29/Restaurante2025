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

namespace SistemaRestaurante.Forms
{
    public partial class UsuariosForm : Form
    {
        public UsuariosForm()
        {
            InitializeComponent();
            this.Load += UsuariosForm_Load;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;

        }
        private void UsuariosForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
            CargarUsuarios();
        }
        private void CargarRoles()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdRol, NombreRol FROM Roles", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbRoles.DataSource = dt;
                cbRoles.DisplayMember = "NombreRol";
                cbRoles.ValueMember = "IdRol";
            }
        }
        private void CargarUsuarios()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT u.IdUsuario, u.Nombre, u.Usuario, r.NombreRol FROM Usuarios u INNER JOIN Roles r ON u.IdRol = r.IdRol", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsuarios.DataSource = dt;
            }
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
                CargarUsuarios();
            }
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
                    CargarUsuarios();

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
                        CargarUsuarios();
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
