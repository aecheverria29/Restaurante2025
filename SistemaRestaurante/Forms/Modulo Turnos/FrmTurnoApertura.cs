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
    public partial class FrmTurnoApertura : Form
    {
        public int NuevoIdTurno {  get; private set; }
        private MainForm main;

        public FrmTurnoApertura(MainForm main)
        {
            InitializeComponent();
            this.Load += FrmTurnoApertura_Load;
            this.main=main;
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
