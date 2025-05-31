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
            PersonalizarEstilo();
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

        private void PersonalizarEstilo()
        {
            // Fondo suave
            this.BackColor = Color.FromArgb(246, 247, 251);

            // ---- Título ----
            label1.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(49, 70, 194);
            label1.AutoSize = true;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            label1.Top = 38;

            // ---- Botones ----
            Button[] btns = { btnTicket, btnFactura, btnSalir };
            Color[] colors = {
        Color.FromArgb(39, 174, 96),     // Verde
        Color.FromArgb(41, 128, 185),    // Azul
        Color.FromArgb(192, 57, 43)      // Rojo para salir
    };

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                btns[i].Width = 160;
                btns[i].Height = 60;
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].FlatAppearance.BorderSize = 0;
                btns[i].ForeColor = Color.White;
                btns[i].BackColor = colors[i];
                btns[i].Cursor = Cursors.Hand;

                int idx = i; // para el closure del evento
                btns[i].MouseEnter += (s, e) => btns[idx].BackColor = ControlPaint.Dark(colors[idx]);
                btns[i].MouseLeave += (s, e) => btns[idx].BackColor = colors[idx];
            }

            // Centrado horizontal de Ticket y Factura
            int btnY = label1.Bottom + 60;
            int btnEspacio = 50;
            int totalWidth = btnTicket.Width + btnFactura.Width + btnEspacio;
            int inicioX = (this.ClientSize.Width - totalWidth) / 2;

            btnTicket.Top = btnFactura.Top = btnY;
            btnTicket.Left = inicioX;
            btnFactura.Left = btnTicket.Right + btnEspacio;

            // Botón Salir abajo y centrado
            btnSalir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalir.Width = 110;
            btnSalir.Height = 38;
            btnSalir.Top = btnTicket.Bottom + 55;
            btnSalir.Left = (this.ClientSize.Width - btnSalir.Width) / 2;
        }

    }
}
