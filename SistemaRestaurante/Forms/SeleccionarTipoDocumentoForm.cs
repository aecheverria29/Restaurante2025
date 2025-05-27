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
        private int idPedido;
        public SeleccionarTipoDocumentoForm(MainForm mainForm , int idPedido)
        {
            InitializeComponent();
            main = mainForm;
            this.idPedido=idPedido;
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new EmitirTicketForm(idPedido));
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            //main.CargarFormulario(new EmitirFacturaForm(idPedido));
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            main.CargarFormulario(new FacturacionForm(main));
        }

        private void SeleccionarTipoDocumentoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
