using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class StockActualForm : Form
    {
        private MainForm main;
        public StockActualForm(MainForm main)
        {
            InitializeComponent();
            this.Load += StockActualForm_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnRefrescar.Click += btnRefrescar_Click;
            btnRegresar.Click += btnRegresar_Click;
            dgvStock.CellFormatting += dgvStock_CellFormatting;
            this.main = main;
        }

        private void StockActualForm_Load(object sender, EventArgs e)
        {
            CargarStock();
            PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo suave
            this.BackColor = Color.FromArgb(246, 247, 251);

            // ---- Título grande ----
            label1.Text = "Lista de insumos con su stock actual";
            label1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(49, 70, 194);
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = 20;

            // ---- Cuadro de búsqueda ----
            txtBuscar.Font = new Font("Segoe UI", 12F);
            txtBuscar.Width = 330;
            txtBuscar.BackColor = Color.White;
            txtBuscar.Top = label1.Bottom + 15;
            txtBuscar.Left = 40;

            // ---- Botón Buscar ----
            btnBuscar.Text = "Buscar";
            btnBuscar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnBuscar.Width = 90;
            btnBuscar.Height = 32;
            btnBuscar.Top = txtBuscar.Top;
            btnBuscar.Left = txtBuscar.Right + 8;
            btnBuscar.BackColor = Color.FromArgb(52, 152, 219);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.MouseEnter += (s, ev) => btnBuscar.BackColor = ControlPaint.Dark(btnBuscar.BackColor);
            btnBuscar.MouseLeave += (s, ev) => btnBuscar.BackColor = Color.FromArgb(52, 152, 219);

            // ---- Botón Refrescar ----
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnRefrescar.Width = 100;
            btnRefrescar.Height = 32;
            btnRefrescar.Top = txtBuscar.Top;
            btnRefrescar.Left = btnBuscar.Right + 18;
            btnRefrescar.BackColor = Color.FromArgb(39, 174, 96);
            btnRefrescar.ForeColor = Color.White;
            btnRefrescar.FlatStyle = FlatStyle.Flat;
            btnRefrescar.FlatAppearance.BorderSize = 0;
            btnRefrescar.Cursor = Cursors.Hand;
            btnRefrescar.MouseEnter += (s, ev) => btnRefrescar.BackColor = ControlPaint.Dark(btnRefrescar.BackColor);
            btnRefrescar.MouseLeave += (s, ev) => btnRefrescar.BackColor = Color.FromArgb(39, 174, 96);

            // ---- DataGridView ----
            dgvStock.Top = txtBuscar.Bottom + 18;
            dgvStock.Left = 30;
            dgvStock.Width = this.ClientSize.Width - 60;
            dgvStock.Height = 250;
            dgvStock.BackgroundColor = Color.White;
            dgvStock.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            dgvStock.DefaultCellStyle.BackColor = Color.White;
            dgvStock.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgvStock.BorderStyle = BorderStyle.FixedSingle;
            dgvStock.AllowUserToAddRows = false;
            dgvStock.ReadOnly = true;

            // ---- Botón Regresar ----
            btnRegresar.Text = "Regresar";
            btnRegresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegresar.Width = 100;
            btnRegresar.Height = 32;
            btnRegresar.BackColor = Color.FromArgb(155, 89, 182);
            btnRegresar.ForeColor = Color.White;
            btnRegresar.FlatStyle = FlatStyle.Flat;
            btnRegresar.FlatAppearance.BorderSize = 0;
            btnRegresar.Cursor = Cursors.Hand;
            btnRegresar.Top = dgvStock.Bottom + 20;
            btnRegresar.Left = this.ClientSize.Width - btnRegresar.Width - 40;
            btnRegresar.MouseEnter += (s, ev) => btnRegresar.BackColor = ControlPaint.Dark(btnRegresar.BackColor);
            btnRegresar.MouseLeave += (s, ev) => btnRegresar.BackColor = Color.FromArgb(155, 89, 182);

            // ---- Asegura que los controles estén arriba ----
            label1.BringToFront();
            txtBuscar.BringToFront();
            btnBuscar.BringToFront();
            btnRefrescar.BringToFront();
            dgvStock.BringToFront();
            btnRegresar.BringToFront();
        }

        private void CargarStock(string filtro = "")
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        i.Nombre,
                        i.Unidad,
                        i.MinimoStock,
                        ISNULL(SUM(CASE 
                            WHEN m.TipoMovimiento = 'Entrada' THEN m.Cantidad 
                            WHEN m.TipoMovimiento = 'Salida' THEN -m.Cantidad 
                            ELSE 0 END), 0) AS StockActual
                    FROM Insumos i
                    LEFT JOIN MovimientoInventario m ON i.IdInsumo = m.IdInsumo
                    WHERE i.Nombre LIKE @filtro
                    GROUP BY i.Nombre, i.Unidad, i.MinimoStock
                    ORDER BY i.Nombre", conn);

                cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStock.DataSource = dt;
            }

            if (dgvStock.Columns.Contains("StockActual"))
                dgvStock.Columns["StockActual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarStock(txtBuscar.Text.Trim());
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarStock();
        }

        private void dgvStock_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStock.Columns[e.ColumnIndex].Name == "StockActual")
            {
                decimal stock = Convert.ToDecimal(dgvStock.Rows[e.RowIndex].Cells["StockActual"].Value);
                decimal minimo = Convert.ToDecimal(dgvStock.Rows[e.RowIndex].Cells["MinimoStock"].Value);

                // Marca de rojo si está en mínimo o menos
                if (stock <= minimo)
                {
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 209, 220);
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new InventarioForm(main));
        }
    }
}
