using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    public partial class FrmTurnoCierre : Form
    {
        private MainForm main;
        public FrmTurnoCierre(MainForm main)
        {
            InitializeComponent();
            this.Load += FrmTurnoCierre_Load;
            this.main=main;
        }
        private DataRow turnoAbierto;
        private void FrmTurnoCierre_Load(object sender, EventArgs e)
        {
            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 t.*, u.Nombre AS NombreCajero " +
                "FROM Turnos t " +
                "JOIN Usuarios u ON t.IdUsuario = u.IdUsuario " +
                "WHERE t.Estado='Abierto' ORDER BY t.FechaInicio DESC", conn))

            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count == 0) { MessageBox.Show("No hay turno abierto"); this.Close(); return; }
                turnoAbierto = dt.Rows[0];
            }

            lblFechaIni.Text = turnoAbierto["FechaInicio"].ToString();
            lblMontoIniVal.Text  = $"{turnoAbierto["MontoInicial"]:C2}";

           
            CalcularVentasPorMetodoPago();
        }

        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            decimal montoFinal = Convert.ToDecimal(lblMontoFinal.Text.Replace("Monto Final en Caja: ", "").Trim().Replace("$", ""));

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(
                 "UPDATE Turnos SET FechaCierre=GETDATE(), MontoFinal=@mf, Estado='Cerrado' WHERE IdTurno=@id", conn))
            {
                cmd.Parameters.AddWithValue("@mf", montoFinal);
                cmd.Parameters.AddWithValue("@id", turnoAbierto["IdTurno"]);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Turno cerrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void CalcularVentasPorMetodoPago()
        {
            decimal efectivo = 0;
            decimal transferencia = 0;
            decimal tarjeta = 0;

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                  using (var cmd = new SqlCommand(@"
                    SELECT mp.Nombre, SUM(f.Total) AS TotalVenta
                    FROM Facturas f
                    INNER JOIN MetodosPago mp ON f.IdMetodoPago = mp.IdMetodoPago
                    WHERE f.IdTurno = @idTurno AND f.Pagado = 1
                    GROUP BY mp.Nombre",conn))
                  {
                        cmd.Parameters.AddWithValue("@idTurno", turnoAbierto["IdTurno"]);
                        using (var rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                string metodoPago = rdr["Nombre"].ToString();
                                decimal totalVenta = Convert.ToDecimal(rdr["TotalVenta"]);

                                switch (metodoPago.ToLower())
                                {
                                    case "efectivo":
                                        efectivo = totalVenta;
                                        break;
                                    case "transferencia":
                                        transferencia = totalVenta;
                                        break;
                                    case "tarjeta":
                                        tarjeta = totalVenta;
                                        break;
                                }
                            }
                        }
                  }  
            }   
            lblEfectivo.Text = $"Efectivo: {efectivo:C2}";
            lblTransferencia.Text = $"Transferencia: {transferencia:C2}";
            lblTarjeta.Text = $"Tarjeta: {tarjeta:C2}";

            decimal totalVentas = efectivo + transferencia + tarjeta;
            lblTotalVentas.Text = $"Total Ventas: {totalVentas:C2}";

            decimal montoInicial = Convert.ToDecimal(turnoAbierto["MontoInicial"]);

            decimal montoFinal = totalVentas + montoInicial;
            lblMontoFinal.Text = $"Monto Final en Caja: {montoFinal:C2}";

            decimal ganancia = totalVentas - montoInicial;
            
            

        }

        private bool GuardarPDFCierre()
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Cierre_Turno_{turnoAbierto["IdTurno"]}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return false;

                try
                {
                    using (var fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    using (var writer = new PdfWriter(fs))
                    using (var pdf = new PdfDocument(writer))
                    using (var doc = new iText.Layout.Document(pdf))
                    {
                        var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        doc.SetFont(font);

                        doc.Add(new Paragraph("Cierre de Turno - PlatyPlus").SetFontSize(14));
                        doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}"));
                        doc.Add(new Paragraph($"Turno ID: {turnoAbierto["IdTurno"]}"));
                        doc.Add(new Paragraph($"Cajero: {turnoAbierto["NombreCajero"]}"));
                        doc.Add(new Paragraph("-------------------------------------------------"));

                        doc.Add(new Paragraph($"Efectivo: {lblEfectivo.Text}"));
                        doc.Add(new Paragraph($"Transferencia: {lblTransferencia.Text}"));
                        doc.Add(new Paragraph($"Tarjeta: {lblTarjeta.Text}"));
                        doc.Add(new Paragraph("-------------------------------------------------"));

                        doc.Add(new Paragraph($"Total Ventas: {lblTotalVentas.Text}"));
                        doc.Add(new Paragraph($"Monto Final: {lblMontoFinal.Text}"));
                        doc.Add(new Paragraph("-------------------------------------------------"));

                        var datosAdicionales = ObtenerTotalesPorTipoConsumo();

                        doc.Add(new Paragraph("Resumen de otros consumos:"));

                        string[] categorias = { "Empleado", "Desperdicio", "Cortesia", "Reposicion" };
                        foreach (var cat in categorias)
                        {
                            decimal valor = datosAdicionales.ContainsKey(cat) ? datosAdicionales[cat] : 0;
                            doc.Add(new Paragraph($"{cat}: {valor:C2}"));
                        }

                        doc.Add(new Paragraph("-------------------------------------------------"));
                        doc.Add(new Paragraph("¡Gracias por utilizar el sistema PlatyPlus!"));

                        Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el PDF:\n" + ex.Message);
                    return false;
                }
            }
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            bool ok = GuardarPDFCierre();
            MessageBox.Show(ok
                ? "PDF generado correctamente."
                : "Fallo la generacion del PDF.");
        }

        private Dictionary<string, decimal> ObtenerTotalesPorTipoConsumo()
        {
            var resultados = new Dictionary<string, decimal>();
            DateTime fechaInicio = (DateTime)turnoAbierto["FechaInicio"];
            DateTime fechaCierre = DateTime.Now;

            using (var conn = DBConnection.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT tc.NombreTipo, SUM(dp.SubTotal) AS Total
                FROM Pedidos p
                INNER JOIN TiposConsumo tc ON p.IdTipoConsumo = tc.IdTipoConsumo
                INNER JOIN DetallePedido dp ON p.IdPedido = dp.IdPedido
                WHERE p.IdEstadoPedido = 3
                AND tc.NombreTipo IN ('Empleado','Desperdicio','Cortesia','Reposicion')
                AND p.Fecha BETWEEN @fechaInicio AND @fechaCierre
                GROUP BY tc.NombreTipo", conn))
            {
                cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@fechaCierre", fechaCierre);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tipo = reader.GetString(0);
                        decimal total = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1);
                        resultados[tipo] = total;
                    }
                }
            }

           
            foreach (var cat in new[] { "Empleado", "Desperdicio", "Cortesia", "Reposicion" })
                if (!resultados.ContainsKey(cat))
                    resultados[cat] = 0m;

            return resultados;
        }


        private void btnCancelarCierre_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


