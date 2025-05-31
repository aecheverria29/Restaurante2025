using SistemaRestaurante.Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    public partial class FrmTurnosMain : Form
    {
        private MainForm main;
        public FrmTurnosMain(MainForm main)
        {
            InitializeComponent();
            this.Load += FrmTurnosMain_Load;
            this.main = main;
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo suave
            this.BackColor = Color.FromArgb(246, 247, 251);

            // Título principal
            label1.Text = "Gestión de Turnos";
            label1.Font = new Font("Segoe UI", 27F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(44, 62, 130);
            label1.AutoSize = true;
            label1.Top = 30;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            // DataGridView de turnos
            dgvTurnos.BackgroundColor = Color.White;
            dgvTurnos.BorderStyle = BorderStyle.FixedSingle;
            dgvTurnos.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            dgvTurnos.DefaultCellStyle.BackColor = Color.White;
            dgvTurnos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 220, 250);
            dgvTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dgvTurnos.Top = label1.Bottom + 30;
            dgvTurnos.Left = (this.ClientSize.Width - dgvTurnos.Width) / 2;
            dgvTurnos.Width = 600;
            dgvTurnos.Height = 200;

            // Botones de acción
            Button[] btns = { btnAbrirTurno, btnCerrarTurno };
            string[] texts = { "Abrir Turno", "Cerrar Turno" };
            Color[] colors = {
                Color.FromArgb(52, 152, 219),   // Azul
                Color.FromArgb(190, 80, 78)     // Rojo
            };
            int btnWidth = 150, btnHeight = 44, gap = 35;
            int btnsTop = dgvTurnos.Bottom + 30;
            int btnsLeft = dgvTurnos.Left + 40;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = btns[i];
                btn.Text = texts[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = btnsTop;
                btn.Left = btnsLeft + i * (btnWidth + gap);
                btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                btn.BackColor = colors[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                int ci = i; // Captura el índice
                btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(colors[ci]);
                btn.MouseLeave += (s, e) => btn.BackColor = colors[ci];
            }

            // Labels de estado y usuario
            lblUsuario.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(44, 62, 80);
            lblUsuario.Top = btnAbrirTurno.Bottom + 40;
            lblUsuario.Left = dgvTurnos.Left + 20;

            lblEstado.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(44, 62, 80);
            lblEstado.Top = lblUsuario.Bottom + 8;
            lblEstado.Left = lblUsuario.Left;
        }

        private void FrmTurnosMain_Load(object sender, EventArgs e)
        {
            CargarTurnos();
            ActualizarEstadoBotones();
        }

        private void CargarTurnos()
        {
            using (var conn = DBConnection.GetConnection())
            using (var da = new SqlDataAdapter(
                @"SELECT TOP 5 
                    t.IdTurno, 
                    (SELECT Nombre FROM Usuarios WHERE IdUsuario = t.IdUsuario) AS Usuario, 
                    t.FechaInicio, 
                    t.FechaCierre, 
                    t.MontoInicial, 
                    t.MontoFinal, 
                    t.Estado 
                FROM Turnos t
                ORDER BY t.FechaInicio DESC", conn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                dgvTurnos.DataSource = dt;
            }
        }

        private DataRow GetTurnoAbierto()
        {
            var dt = new DataTable();
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 t.*, u.Nombre AS NombreUsuario " +
                "FROM Turnos t " +
                "JOIN Usuarios u ON t.IdUsuario = u.IdUsuario " +
                "WHERE t.Estado = 'Abierto' " +
                "ORDER BY t.FechaInicio DESC", conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

        private void ActualizarEstadoBotones()
        {
            var abierto = GetTurnoAbierto();
            btnAbrirTurno.Enabled = abierto == null;
            btnCerrarTurno.Enabled = abierto != null;
            if (abierto != null)
            {
                lblUsuario.Text = $"Cajero actual: {abierto["NombreUsuario"]}";
                lblEstado.Text = $"Turno abierto desde: {abierto["FechaInicio"]}";
            }
            else
            {
                lblUsuario.Text = "Usuario: -";
                lblEstado.Text = "No hay turno abierto";
            }
        }

        private void btnAbrirTurno_Click(object sender, EventArgs e)
        {
            var frm = new FrmTurnoApertura(main);
            main.CargarFormulario(frm);
            frm.FormClosed += (s, args) =>
            {
                main.CargarFormulario(new FrmTurnosMain(main));
            };
        }

        private void btnCerrarTurno_Click(object sender, EventArgs e)
        {
            var frm = new FrmTurnoCierre(main);
            main.CargarFormulario(frm);
            frm.FormClosed += (s, args) =>
            {
                main.CargarFormulario(new FrmTurnosMain(main));
            };
        }

        private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Puedes implementar detalles aquí si es necesario
        }
    }
}
