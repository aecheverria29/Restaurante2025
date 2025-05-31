using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    public partial class FrmTurnoApertura : Form
    {
        public int NuevoIdTurno { get; private set; }
        private MainForm main;

        public FrmTurnoApertura(MainForm main)
        {
            InitializeComponent();
            this.Load += FrmTurnoApertura_Load;
            this.main = main;
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo
            this.BackColor = Color.FromArgb(246, 247, 251);

            // ---- Título ----
            label1.Text = "Apertura de Turno";
            label1.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 130);
            label1.AutoSize = true;
            label1.Top = 32;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            // ---- Labels ----
            Label[] labels = { lblSelUsuario, lblMontoIni };
            string[] texts = { "Seleccione usuario:", "Monto inicial:" };
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = texts[i];
                labels[i].Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                labels[i].ForeColor = Color.FromArgb(49, 70, 130);
            }

            int leftLbl = 140, leftInput = 340, topIni = label1.Bottom + 50, gapY = 60;
            lblSelUsuario.Top = topIni;
            lblSelUsuario.Left = leftLbl;
            lblMontoIni.Top = topIni + gapY;
            lblMontoIni.Left = leftLbl;

            // ---- ComboBox Usuarios ----
            cmbUsuarios.Font = new Font("Segoe UI", 12F);
            cmbUsuarios.Width = 220;
            cmbUsuarios.Left = leftInput;
            cmbUsuarios.Top = lblSelUsuario.Top - 4;
            cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuarios.BackColor = Color.White;

            // ---- NumericUpDown Monto Inicial ----
            nudMontoInicial.Font = new Font("Segoe UI", 12F);
            nudMontoInicial.Width = 120;
            nudMontoInicial.Left = leftInput;
            nudMontoInicial.Top = lblMontoIni.Top - 4;
            nudMontoInicial.DecimalPlaces = 2;
            nudMontoInicial.Minimum = 0;
            nudMontoInicial.Maximum = 100000;
            nudMontoInicial.BackColor = Color.White;

            // ---- Botones ----
            Button[] btns = { btnGuardarApertura, btnCancelar };
            string[] btnTexts = { "Abrir Turno", "Cancelar" };
            Color[] btnColors = { Color.FromArgb(36, 182, 95), Color.FromArgb(190, 80, 78) };
            int btnWidth = 170, btnHeight = 45, gapBtn = 40;
            int btnsTop = nudMontoInicial.Bottom + 55;
            int btnsLeft = leftLbl;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = btns[i];
                btn.Text = btnTexts[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = btnsTop;
                btn.Left = btnsLeft + i * (btnWidth + gapBtn);
                btn.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                btn.BackColor = btnColors[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                //btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(btnColors[i]);
               // btn.MouseLeave += (s, e) => btn.BackColor = btnColors[i];
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarApertura_Click(object sender, EventArgs e)
        {
            var idUsu = (int)cmbUsuarios.SelectedValue;
            var monto = nudMontoInicial.Value;

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(
                 "INSERT INTO Turnos (IdUsuario, MontoInicial, Estado) VALUES (@u,@m,'Abierto'); SELECT SCOPE_IDENTITY();",
                 conn))
            {
                cmd.Parameters.AddWithValue("@u", idUsu);
                cmd.Parameters.AddWithValue("@m", monto);
                conn.Open();
                NuevoIdTurno = Convert.ToInt32(cmd.ExecuteScalar());
            }

            MessageBox.Show("Turno abierto correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cargar el formulario principal de turnos otra vez en el panel principal
            main.CargarFormulario(new FrmTurnosMain(main));
            this.Close();
        }

        private void FrmTurnoApertura_Load(object sender, EventArgs e)
        {
            using (var conn = DBConnection.GetConnection())
            using (var da = new SqlDataAdapter("SELECT IdUsuario, Nombre FROM Usuarios", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                cmbUsuarios.DataSource = dt;
                cmbUsuarios.DisplayMember = "Nombre";
                cmbUsuarios.ValueMember = "IdUsuario";
            }
        }
    }
}
