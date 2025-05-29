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
using SistemaRestaurante.Forms.Modulo_Turnos;              // <- para Document

namespace SistemaRestaurante.Forms
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // O DARK
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600, Primary.Blue700,
                Primary.Blue200, Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Region = new Region(path);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Centra horizontalmente
            pictureBox1.Left = (panelMenu.Width - pictureBox1.Width) / 2;
            // Opcional: establece la ubicación en Y (Top)
            pictureBox1.Top = 20;
           

        }


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

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
           
            AbrirFormularioEnPanel(new UsuariosForm(this));
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new MenuForm());
        }

        private void btnPlatos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new PlatosForm());
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new PedidosForm(this));
        }

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

        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FacturacionForm(this));
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmTurnosMain(this));
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new UsuariosForm(this));
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new MenuForm());
        }

        private void btnPlatos_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new PlatosForm());
        }

        private void btnPedidos_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new PedidosForm(this));
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {

        }

        private void btnFacturacion_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FacturacionForm(this));
        }

        private void btnTurnos_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmTurnosMain(this));

        }

        private void btnCerrarSesion_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {
            // Degradado vertical tipo PlatyPlus
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                panelMenu.ClientRectangle,
                Color.FromArgb(72, 49, 240),    // Color arriba (azul fuerte)
                Color.FromArgb(199, 195, 255),  // Color abajo (azul/violeta claro)
                System.Drawing.Drawing2D.LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, panelMenu.ClientRectangle);
            }
        }
    }
}
