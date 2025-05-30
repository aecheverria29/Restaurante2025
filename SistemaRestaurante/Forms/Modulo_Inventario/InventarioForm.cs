using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    public partial class InventarioForm : Form
    {
        private MainForm main;
        public InventarioForm(MainForm main)
        {
            InitializeComponent();
            this.main=main;
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
