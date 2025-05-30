using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class InventarioForm : Form
    {
        private MainForm main;
        public InventarioForm(MainForm main)
        {
            InitializeComponent();
            this.main = main;
            this.Load += InventarioForm_Load;
        }

        private void InventarioForm_Load(object sender, EventArgs e)
        {
            // -------- Fondo --------
            this.BackColor = Color.FromArgb(246, 247, 251);

            // -------- Título --------
            label1.Text = "Bienvenido a manejo de inventario";
            label1.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(49, 70, 194);
            label1.AutoSize = true;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = 36;

            label2.Text = "¿Qué desea realizar?";
            label2.Font = new Font("Segoe UI Semibold", 19F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(50, 57, 120);
            label2.AutoSize = true;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            label2.Top = label1.Bottom + 12;

            // -------- Labels de opción --------
            Label[] labels = { label3, label4, label5 };
            string[] labelTexts = {
                "Agregar / Editar insumos",
                "Registrar compras o pérdidas",
                "Consultar el Stock"
            };
            int leftLabels = 140;
            int leftButtons = 440;
            int topStart = label2.Bottom + 36;
            int gapY = 64;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = labelTexts[i];
                labels[i].Font = new Font("Segoe UI", 16F, FontStyle.Regular);
                labels[i].ForeColor = Color.FromArgb(65, 68, 108);
                labels[i].Top = topStart + i * gapY;
                labels[i].Left = leftLabels;
                labels[i].AutoSize = true;
            }

            // -------- Botones --------
            Button[] btns = { btnInsumos, btnMovimiento, btnStock };
            string[] btnTexts = { "Insumos", "Movimiento inventario", "Stock" };
            Color[] btnColors =
            {
                Color.FromArgb(44, 204, 113),    // Verde
                Color.FromArgb(52, 152, 219),    // Azul
                Color.FromArgb(155, 89, 182)     // Morado
            };

            int btnWidth = 240, btnHeight = 52;
            int btnTopStart = topStart - 8;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = btns[i];
                btn.Text = btnTexts[i];
                btn.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = btnTopStart + i * gapY;
                btn.Left = leftButtons;
                btn.BackColor = btnColors[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                btn.TabStop = false;

                // --- Hover efecto ---
                int colorIndex = i; // Necesario para el closure del evento
                btn.MouseEnter += (s, ev) => btn.BackColor = ControlPaint.Dark(btnColors[colorIndex]);
                btn.MouseLeave += (s, ev) => btn.BackColor = btnColors[colorIndex];
            }
        }

        private void btnInsumos_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new InsumosForm(main));
        }

        private void btnMovimiento_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new MovimientoInventarioForm(main));
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new StockActualForm(main));
        }
    }
}
