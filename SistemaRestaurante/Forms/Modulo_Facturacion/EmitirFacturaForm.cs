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
    
    public partial class EmitirFacturaForm : Form
    {
        private MainForm main;
        public EmitirFacturaForm(MainForm mainForm)
        {
            InitializeComponent();
            main=mainForm;
            PersonalizarEstilo();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtNumControl_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtXML_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PersonalizarEstilo()
        {
            // Fondo suave
            this.BackColor = Color.FromArgb(247, 249, 253);

            // ----- Labels -----
            Label[] labels = { label1, label2, label3, label4, label5, label6, label7 };
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                lbl.ForeColor = Color.FromArgb(44, 62, 80);
                lbl.AutoSize = true;
            }

            // ----- TextBox -----
            TextBox[] txts = { txtNombreCliente, txtNIT, txtNRC, txtCorreo, txtSerie, txtNumControl, txtXML };
            foreach (var t in txts)
            {
                t.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                t.BackColor = Color.White;
                t.BorderStyle = BorderStyle.FixedSingle;
            }

            // ----- ComboBox -----
            cbMetodoPago.Font = new Font("Segoe UI", 11F);

            // ----- Botones -----
            Button[] btns = { btnBuscar, btnFacturar };
            Color[] colors = { Color.FromArgb(52, 152, 219), Color.FromArgb(39, 174, 96) };
            string[] texts = { "Buscar Cliente", "Ejecutar Facturación" };

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btns[i].BackColor = colors[i];
                btns[i].ForeColor = Color.White;
                btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].FlatAppearance.BorderSize = 0;
                btns[i].Cursor = Cursors.Hand;
                btns[i].Height = 36;
                btns[i].Text = texts[i];
                int idx = i;
                btns[i].MouseEnter += (s, e) => btns[idx].BackColor = ControlPaint.Dark(colors[idx]);
                btns[i].MouseLeave += (s, e) => btns[idx].BackColor = colors[idx];
            }

            // Puedes ajustar aquí los tamaños/ubicaciones si lo necesitas
        }

    }
}
