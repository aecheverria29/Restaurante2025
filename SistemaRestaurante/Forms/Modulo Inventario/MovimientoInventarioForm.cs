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

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class MovimientoInventarioForm : Form
    {
        public MovimientoInventarioForm()
        {
            InitializeComponent();
            this.Load += MovimientoInventarioForm_Load;
            btnRegistrar.Click += btnRegistrar_Click;
        }

        private void MovimientoInventarioForm_Load(object sender, EventArgs e)
        {
            CargarInsumos();
            CargarMovimientos();

            rbEntrada.Checked = true;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void CargarInsumos()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdInsumo, Nombre FROM Insumos",conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbInsumo.DataSource = dt;
                cbInsumo.DisplayMember = "Nombre";
                cbInsumo.ValueMember = "IdInsumo";
            }
        }
        private void CargarMovimientos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT m.Fecha, i.Nombre AS Insumo, m.TipoMovimiento, m.Cantidad, m.Justificacion
                    FROM MovimientoInventariio m
                    INNER JOIN Insumos i ON m.IdInsumo = i.IdInsumo
                    ORDER BY m.Fecha DESC", conn);
                SqlDataAdapter da = new SqlDataAdapter( cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovimientos.DataSource = dt;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (cbInsumo.SelectedValue == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Completa todos los campos obligatorios.");
                return;
            }

            decimal cantidad;
            if(!decimal.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad no valida");
                return;
            }

            string tipo = rbEntrada.Checked ? "Entrada" : "Salida";
            string justificacion = string.IsNullOrWhiteSpace(txtJustificacion.Text) ? "Sin Justificacion" : txtJustificacion.Text;
            int idInsumo = Convert.ToInt32(cbInsumo.SelectedValue);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO MovimientoInventario (IdInsumo, Fecha, TipoMovimiento, Cantidad, Justificacion)
                    VALUES (@insumo, GETDATE(), @tipo, @cantidad, @justif)", conn);

                cmd.Parameters.AddWithValue("@insumo", idInsumo);
                cmd.Parameters.AddWithValue("@tipo", tipo);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@justif", justificacion);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Movimiento registrado correctamente.");
                LimpiarCampos();
                CargarMovimientos();
            }
        }
        private void LimpiarCampos()
        {
            cbInsumo.SelectedIndex = 0;
            txtCantidad.Clear();
            txtJustificacion.Clear();
            rbEntrada.Checked = true;
        }
    }
}
