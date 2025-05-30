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

    public partial class StockActualForm : Form
    {
        private MainForm main;
        public StockActualForm( MainForm main)
        {
            InitializeComponent();
            this.Load += StockActualForm_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnRefrescar.Click += btnRefrescar_Click;
            dgvStock.CellFormatting += dgvStock_CellFormatting;
            this.main=main;
        }

        private void StockActualForm_Load(object sender, EventArgs e)
        {
            CargarStock();
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

                if (stock <= minimo)
                {
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                }
                else
                {
                    dgvStock.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new InventarioForm(main));
        }
    }
}

