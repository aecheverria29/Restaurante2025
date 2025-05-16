using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRestaurante.Services;

namespace SistemaRestaurante.Utils
{
    internal class UtilidadesUI
    {
        public static void CargarRoles(ComboBox cbRoles)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
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

        public static void CargarUsuarios(DataGridView dgvUsuarios)
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
        public static void CargarCategorias(ComboBox cbCategoriaPadre, DataGridView dgvCategorias)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdCategoria, Nombre FROM Categorias", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbCategoriaPadre.DataSource = dt;
                cbCategoriaPadre.DisplayMember = "Nombre";
                cbCategoriaPadre.ValueMember = "IdCategoria";

                dgvCategorias.DataSource = dt;
            }
        }
        public static void CargarSubcategorias(DataGridView dgvSubCategorias)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT s.IdSubcategoria, s.Nombre, c.Nombre AS Categoria FROM Subcategorias s INNER JOIN Categorias c ON s.IdCategoria = c.IdCategoria", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubCategorias.DataSource = dt;
            }
        }
    }
}
