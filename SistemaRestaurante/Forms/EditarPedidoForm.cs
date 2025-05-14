using SistemaRestaurante.Models;
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

namespace SistemaRestaurante.Forms
{
    public partial class EditarPedidoForm : Form
    {
        private int idPedido;
        List<PlatoPedidoTemp> listaDetalle = new List<PlatoPedidoTemp>();

        public EditarPedidoForm(int id)
        {
            InitializeComponent();
            idPedido = id;
            this.Load += EditarPedidoForm_Load;
        }

        private void EditarPedidoForm_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDatosPedido();
            CargarDetallePedido();
        }

        private void CargarCombos()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();

                //Cargar mesas disponibles
                SqlCommand cmdMesas = new SqlCommand("SELECT IdMesa,NumeroMesa FROM Mesas WHERE IdEstadoMesa = 1", conn);
                SqlDataAdapter daMesas = new SqlDataAdapter(cmdMesas);
                DataTable dtMesas = new DataTable();
                daMesas.Fill(dtMesas);
                cbMesa.DataSource = dtMesas;
                cbMesa.DisplayMember = "NumeroMesa";
                cbMesa.ValueMember = "IdMesa";

                SqlCommand cmdTipos = new SqlCommand("SELECT IdTipoConsumo, NombreTipo FROM TiposConsumo", conn);
                SqlDataAdapter daTipos = new SqlDataAdapter(cmdTipos);
                DataTable dtTipos = new DataTable();
                daTipos.Fill(dtTipos);
                cbTipoConsumo.DataSource = dtTipos;
                cbTipoConsumo.DisplayMember = "NombreTipo";
                cbTipoConsumo.ValueMember = "IdTipoConsumo";

                // Cargar platos
                SqlCommand cmdPlatos = new SqlCommand("SELECT IdPlato, Nombre, Precio FROM Platos WHERE Disponible = 1", conn);
                SqlDataAdapter daPlatos = new SqlDataAdapter(cmdPlatos);
                DataTable dtPlatos = new DataTable();
                daPlatos.Fill(dtPlatos);
                cbPlato.DataSource = dtPlatos;
                cbPlato.DisplayMember = "Nombre";
                cbPlato.ValueMember = "IdPlato";
            }
        }

        private void CargarDatosPedido()
        {
            using(SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT IdMesa, IdTipoConsumo, Justificacion
                    FROM Pedidos
                    WHERE IdPedido = @id", conn);
                cmd.Parameters.AddWithValue("@id", idPedido);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cbMesa.SelectedValue = Convert.ToInt32(reader["IdMesa"]);
                    cbTipoConsumo.SelectedValue = Convert.ToInt32(reader["IdTipoConsumo"]);
                    txtJustificacion.Text = reader["Justificacion"].ToString();
                }
            }
        }
        private void CargarDetallePedido()
        {
            listaDetalle.Clear();
            using(SqlConnection con = DBConnection.GetConnection())
            {
                con.Open();
                //string query 
            }
        }
    }
}
