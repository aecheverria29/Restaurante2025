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
    public partial class SeleccionarTipoDocumentoForm : Form
    {
        private MainForm main;
        public SeleccionarTipoDocumentoForm(MainForm main)
        {
            InitializeComponent();
            this.main=main;
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new EmitirTicketForm(main));
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new EmitirFacturaForm(main));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new FacturacionForm(main));
        }
    }
}
