using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class MovimientoInventarioForm : Form
    {
        private MainForm main;
        public MovimientoInventarioForm(MainForm main)
        {
            InitializeComponent();
            this.Load += MovimientoInventarioForm_Load;
            btnRegistrar.Click += btnRegistrar_Click;
            btnFiltrar.Click += btnFiltrar_Click;
            btnRegresar.Click += btnRegresar_Click;
            this.main = main;
        }

        private void MovimientoInventarioForm_Load(object sender, EventArgs e)
        {
            CargarInsumos();
            CargarMovimientos();
            CargarFiltroInsumos();

            rbEntrada.Checked = true;
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // --- ESTILOS MODERNOS ---
            this.BackColor = Color.FromArgb(246, 247, 251);

            // Labels principales
            label1.Text = "Seleccionar insumo";
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(56, 65, 120);

            label2.Text = "Cantidad que entra o sale";
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(56, 65, 120);

            label3.Text = "Motivo del movimiento";
            label3.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(56, 65, 120);

            label4.Text = "Historial de movimientos por insumo o fecha";
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(56, 65, 120);

            // ComboBox y entradas
            cbInsumo.Font = new Font("Segoe UI", 12F);
            cbInsumo.BackColor = Color.White;

            cbFiltroInsumo.Font = new Font("Segoe UI", 11F);
            cbFiltroInsumo.BackColor = Color.White;

            txtCantidad.Font = new Font("Segoe UI", 12F);
            txtCantidad.BackColor = Color.White;

            txtJustificacion.Font = new Font("Segoe UI", 12F);
            txtJustificacion.BackColor = Color.White;

            // RadioButtons
            rbEntrada.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            rbEntrada.ForeColor = Color.FromArgb(40, 167, 69);

            rbSalida.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            rbSalida.ForeColor = Color.FromArgb(231, 76, 60);

            // Botón registrar
            btnRegistrar.Text = "Guardar movimiento";
            btnRegistrar.Width = 180;
            btnRegistrar.Height = 38;
            btnRegistrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRegistrar.BackColor = Color.FromArgb(52, 152, 219);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.TabStop = false;
            btnRegistrar.MouseEnter += (s, ev) => btnRegistrar.BackColor = ControlPaint.Dark(btnRegistrar.BackColor);
            btnRegistrar.MouseLeave += (s, ev) => btnRegistrar.BackColor = Color.FromArgb(52, 152, 219);

            // Botón Filtrar
            btnFiltrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnFiltrar.BackColor = Color.FromArgb(39, 174, 96);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.Cursor = Cursors.Hand;
            btnFiltrar.TabStop = false;
            btnFiltrar.Width = 100;
            btnFiltrar.Height = 32;
            btnFiltrar.MouseEnter += (s, ev) => btnFiltrar.BackColor = ControlPaint.Dark(btnFiltrar.BackColor);
            btnFiltrar.MouseLeave += (s, ev) => btnFiltrar.BackColor = Color.FromArgb(39, 174, 96);

            // Botón regresar
            btnRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegresar.BackColor = Color.FromArgb(155, 89, 182);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.TabStop = false;
            btnRegresar.Width = 100;
            btnRegresar.Height = 32;
            btnRegresar.MouseEnter += (s, ev) => btnRegresar.BackColor = ControlPaint.Dark(btnRegresar.BackColor);
            btnRegresar.MouseLeave += (s, ev) => btnRegresar.BackColor = Color.FromArgb(155, 89, 182);

            // DataGridView
            dgvMovimientos.Font = new Font("Segoe UI", 11F);
            dgvMovimientos.BackgroundColor = Color.White;
            dgvMovimientos.DefaultCellStyle.BackColor = Color.White;
            dgvMovimientos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvMovimientos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            // --- Posicionamiento visual (solo para vista, no obligatorio si lo tienes en el diseñador) ---
            label1.Top = 30; label1.Left = 32;
            cbInsumo.Top = label1.Top - 3; cbInsumo.Left = 210;

            rbEntrada.Top = label1.Top; rbEntrada.Left = cbInsumo.Right + 40;
            rbSalida.Top = rbEntrada.Top; rbSalida.Left = rbEntrada.Right + 60;

            label2.Top = cbInsumo.Bottom + 24; label2.Left = 32;
            txtCantidad.Top = label2.Top - 2; txtCantidad.Left = 270;

            label3.Top = label2.Top; label3.Left = txtCantidad.Right + 50;
            txtJustificacion.Top = label3.Top - 2; txtJustificacion.Left = label3.Right + 8;

            label4.Top = txtCantidad.Bottom + 30; label4.Left = 32;

            dgvMovimientos.Top = label4.Bottom + 6; dgvMovimientos.Left = 32;
            dgvMovimientos.Width = 450; dgvMovimientos.Height = 180;

            btnRegistrar.Top = dgvMovimientos.Top + 32; btnRegistrar.Left = dgvMovimientos.Right + 30;

            cbFiltroInsumo.Top = dgvMovimientos.Bottom + 20; cbFiltroInsumo.Left = 32;
            btnFiltrar.Top = cbFiltroInsumo.Top; btnFiltrar.Left = cbFiltroInsumo.Right + 20;

            btnRegresar.Top = cbFiltroInsumo.Top; btnRegresar.Left = this.ClientSize.Width - btnRegresar.Width - 20;
        }

        private void CargarInsumos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdInsumo, Nombre FROM Insumos", conn);
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
                SELECT 
                    m.Fecha, 
                    i.Nombre AS Insumo, 
                    m.TipoMovimiento, 
                    m.Cantidad, 
                    m.Justificacion
                FROM MovimientoInventario m
                INNER JOIN Insumos i ON m.IdInsumo = i.IdInsumo
                WHERE CAST(m.Fecha AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY m.Fecha DESC", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
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
            if (!decimal.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cbFiltroInsumo.SelectedIndex == -1 || cbFiltroInsumo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un insumo para filtrar.");
                return;
            }

            int idInsumo = Convert.ToInt32(cbFiltroInsumo.SelectedValue);

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                m.Fecha, 
                i.Nombre AS Insumo, 
                m.TipoMovimiento, 
                m.Cantidad, 
                m.Justificacion
            FROM MovimientoInventario m
            INNER JOIN Insumos i ON m.IdInsumo = i.IdInsumo
            WHERE m.IdInsumo = @id AND CAST(m.Fecha AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY m.Fecha DESC", conn);

                cmd.Parameters.AddWithValue("@id", idInsumo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMovimientos.DataSource = dt;
            }
        }
        private void CargarFiltroInsumos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdInsumo, Nombre FROM Insumos", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbFiltroInsumo.DataSource = dt;
                cbFiltroInsumo.DisplayMember = "Nombre";
                cbFiltroInsumo.ValueMember = "IdInsumo";
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new InventarioForm(main));
        }
    }
}
