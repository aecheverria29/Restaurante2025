using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;
using SistemaRestaurante.Forms.Modulo_Turnos;

namespace SistemaRestaurante.Forms
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo600, Primary.Indigo700,
                Primary.Indigo200, Accent.LightBlue200,
                TextShade.WHITE
            );
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 1. Imagen redonda centrada con borde violeta
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Left = (panelMenu.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = 24;

            // Dibuja borde violeta claro (opcional)
            pictureBox1.Paint += (s, pe) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(150, 120, 160, 255), 4))
                {
                    pe.Graphics.DrawEllipse(pen, 2, 2, pictureBox1.Width - 4, pictureBox1.Height - 4);
                }
            };

            // 2. Estilo y posición de los botones del menú
            List<MaterialButton> botonesMenu = new List<MaterialButton>
            {
                btnUsuarios,
                btnMenu,
                btnPlatos,
                btnPedidos,
                btnInventario,
                btnFacturacion,
                btnTurnos,
                btnMesas,
                btnReportes,
                btnCerrarSesion
            };

            int anchoBoton = 180;
            int altoBoton = 48;
            int espacioEntreBotones = 16;

            int alturaTotal = botonesMenu.Count * altoBoton + (botonesMenu.Count - 1) * espacioEntreBotones;
            int topInicial = pictureBox1.Bottom + 36;

            for (int i = 0; i < botonesMenu.Count; i++)
            {
                var btn = botonesMenu[i];
                btn.AutoSize = false;
                btn.Size = new Size(anchoBoton, altoBoton);
                btn.Left = (panelMenu.Width - anchoBoton) / 2;
                btn.Top = topInicial + i * (altoBoton + espacioEntreBotones);

                btn.Font = new Font("Segoe UI Semibold", 13, FontStyle.Bold);
                btn.ForeColor = Color.White;

                // Fondo degradado individual (azul a celeste)
                btn.BackColor = Color.Transparent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.Paint += (s, pe) =>
                {
                    var b = (Button)s;
                    Rectangle rect = new Rectangle(0, 0, b.Width, b.Height);
                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        rect,
                        Color.FromArgb(90, 140, 255), // Azul celeste
                        Color.FromArgb(88, 230, 255), // Celeste pastel
                        LinearGradientMode.Vertical))
                    {
                        pe.Graphics.FillRectangle(brush, rect);
                    }
                    // Bordes redondeados
                    using (GraphicsPath roundRect = RoundedRect(rect, 18))
                    {
                        b.Region = new Region(roundRect);
                    }
                };

                // Sombra (opcional)
                btn.Refresh();
                btn.Invalidate();
            }
        }

        // Helper para bordes redondeados
        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        // ==== Tu lógica de navegación y eventos ====
        private void AbrirFormularioEnPanel(Form formHijo)
        {
            if (panelContenido.Controls.Count > 0)
                panelContenido.Controls.RemoveAt(0);
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formHijo);
            panelContenido.Tag = formHijo;
            formHijo.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new UsuariosForm(this));
        private void btnMenu_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new MenuForm());
        private void btnPlatos_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new PlatosForm());
        private void btnCerrarSesion_Click(object sender, EventArgs e) => this.Close();
        private void btnPedidos_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new PedidosForm(this));
        public void CargarFormulario(Form formulario)
        {
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenido.Controls.Clear();
            panelContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void panelContenido_Paint(object sender, PaintEventArgs e)
        {
            // No necesitas código aquí de momento.
        }

        private void btnFacturacion_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new FacturacionForm(this));
        private void btnTurnos_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new FrmTurnosMain(this));
        private void btnUsuarios_Click_1(object sender, EventArgs e) => AbrirFormularioEnPanel(new UsuariosForm(this));
        private void btnMenu1_Click(object sender, EventArgs e) => AbrirFormularioEnPanel(new MenuForm());
        private void btnPlatos_Click_1(object sender, EventArgs e) => AbrirFormularioEnPanel(new PlatosForm());
        private void btnPedidos_Click_1(object sender, EventArgs e) => AbrirFormularioEnPanel(new PedidosForm(this));
        private void btnInventario_Click(object sender, EventArgs e) { }
        private void btnFacturacion_Click_1(object sender, EventArgs e) => AbrirFormularioEnPanel(new FacturacionForm(this));
        private void btnTurnos_Click_1(object sender, EventArgs e) => AbrirFormularioEnPanel(new FrmTurnosMain(this));
        private void btnCerrarSesion_Click_1(object sender, EventArgs e) => this.Close();

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            // Fondo degradado vertical
            using (var brush = new LinearGradientBrush(
                panelMenu.ClientRectangle,
                ColorTranslator.FromHtml("#6345F5"),    // Arriba
                ColorTranslator.FromHtml("#B0B5FF"),    // Abajo
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panelMenu.ClientRectangle);
            }
        }
    }
}
