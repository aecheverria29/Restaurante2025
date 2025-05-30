using SistemaRestaurante.Forms.Modulo_Inventario;
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
using Microsoft.VisualBasic;


namespace SistemaRestaurante.Forms
{
    public partial class MesasForm : Form
    {
        private MainForm main;
        private ContextMenuStrip menuMesa;
        private int mesaSeleccionadaId = -1;
        public MesasForm(MainForm mainForm)
        {
            InitializeComponent();
            main=mainForm;
            this.Load += MesasForm_Load;
            btnAgregar.Click += btnAgregar_Click;
            btnLimpiar.Click += btnLimpiar_Click;
            btnRegresar.Click += btnRegresar_Click;
            InicializarMenuContextual();
        }
        private void InicializarMenuContextual()
        {
            menuMesa = new ContextMenuStrip();
            menuMesa.Items.Add("Editar", null, MenuEditar_Click);
            menuMesa.Items.Add("Eliminar", null, MenuEliminar_Click);
        }
        private void MesasForm_Load(object sender, EventArgs e)
        {
            CargarMesasVisual();
        }
        private void CargarMesasVisual()
        {
            flpMesas.Controls.Clear(); // Limpia panel

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT m.IdMesa, m.NumeroMesa, em.NombreEstado
                    FROM Mesas m
                    INNER JOIN EstadoMesa em ON m.IdEstadoMesa = em.IdEstadoMesa", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    int idMesa = Convert.ToInt32(row["IdMesa"]);
                    string numero = row["NumeroMesa"].ToString();
                    string estado = row["NombreEstado"].ToString();

                    Button btn = new Button();
                    btn.Text = "" + numero;
                    btn.Width = 100;
                    btn.Height = 60;
                    btn.Tag = idMesa;

                    // Color según estado
                    switch (estado)
                    {
                        case "Libre":
                            btn.BackColor = Color.LightGreen;
                            break;
                        case "Ocupada":
                            btn.BackColor = Color.IndianRed;
                            break;
                        case "Reservada":
                            btn.BackColor = Color.Gold;
                            break;
                        default:
                            btn.BackColor = Color.LightGreen;
                            break;
                    }

                    btn.Click += BtnMesa_Click;

                    btn.MouseUp += (s, e) =>
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            mesaSeleccionadaId = (int)((Button)s).Tag;
                            txtNumero.Text = ((Button)s).Text;
                            menuMesa.Show(Cursor.Position);
                        }
                    };


                    flpMesas.Controls.Add(btn);
                }
            }
        }
        private void BtnMesa_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idMesa = (int)btn.Tag;

            
            NuevoPedidoForm nuevoPedido = new NuevoPedidoForm(main, idMesa);
            main.CargarFormulario(nuevoPedido);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumero.Text))
            {
                MessageBox.Show("Ingrese un número de mesa.");
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Mesas (NumeroMesa, IdEstadoMesa) VALUES (@numero, 1)", conn);
                cmd.Parameters.AddWithValue("@numero", txtNumero.Text);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Mesa agregada correctamente.");
            LimpiarCampos();
            CargarMesasVisual();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNumero.Clear();
            mesaSeleccionadaId = -1;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MenuEditar_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionadaId <= 0)
            {
                MessageBox.Show("Seleccione una mesa válida.");
                return;
            }

            string nuevoNumero = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el nuevo número para la mesa:", "Editar Mesa", txtNumero.Text);

            if (string.IsNullOrWhiteSpace(nuevoNumero))
            {
                MessageBox.Show("Número inválido.");
                return;
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Mesas SET NumeroMesa = @numero WHERE IdMesa = @id", conn);
                cmd.Parameters.AddWithValue("@numero", nuevoNumero);
                cmd.Parameters.AddWithValue("@id", mesaSeleccionadaId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Mesa actualizada correctamente.");
            LimpiarCampos();
            CargarMesasVisual();
        }


        private void MenuEliminar_Click(object sender, EventArgs e)
        {
            if (mesaSeleccionadaId <= 0)
            {
                MessageBox.Show("Seleccione una mesa para eliminar.");
                return;
            }

            DialogResult result = MessageBox.Show("¿Seguro que desea eliminar esta mesa?", "Confirmación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Mesas WHERE IdMesa = @id", conn);
                    cmd.Parameters.AddWithValue("@id", mesaSeleccionadaId);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Mesa eliminada.");
                LimpiarCampos();
                CargarMesasVisual();
            }
        }

    }
}
