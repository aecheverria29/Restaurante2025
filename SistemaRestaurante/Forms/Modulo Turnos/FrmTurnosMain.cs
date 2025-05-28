    using SistemaRestaurante.Services;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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
                this.main=main;
            }

            private void btnAbrirTurno_Click(object sender, EventArgs e)
            {
            var frm = new FrmTurnoApertura(main);
            main.CargarFormulario(frm);

            // Recargar TurnosMain cuando se cierre
            frm.FormClosed += (s, args) =>
            {
                main.CargarFormulario(new FrmTurnosMain(main));
            };
        }

            private void btnCerrarTurno_Click(object sender, EventArgs e)
            {
                var frm = new FrmTurnoCierre(main);
                main.CargarFormulario(frm); // Carga el formulario

                // Escucha el evento FormClosed
                frm.FormClosed += (s, args) =>
                {
                    // Cuando se cierre, recarga TurnosMain automáticamente
                    main.CargarFormulario(new FrmTurnosMain(main));
                };
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

            private void dgvTurnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        }
    }
