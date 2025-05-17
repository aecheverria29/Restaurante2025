using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
    }
}
