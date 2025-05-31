using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using SistemaRestaurante.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    public partial class FrmTurnoCierre : Form
    {
        private MainForm main;
        private DataRow turnoAbierto;

        public FrmTurnoCierre(MainForm main)
        {
            InitializeComponent();
            this.Load += FrmTurnoCierre_Load;
            this.main = main;
            this.Load += (s, e) => PersonalizarEstilo();
        }

        private void PersonalizarEstilo()
        {
            // Fondo y fuente general
            this.BackColor = Color.FromArgb(248, 248, 252);
            this.Font = new Font("Segoe UI", 12);

            // --- Título ---
            label2.Text = "Corte de caja";
            label2.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(44, 62, 130);
            label2.AutoSize = true;
            label2.Top = 30;
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;

            // --- Fechas y Monto inicial ---
            lblFechaIni.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFechaIni.ForeColor = Color.FromArgb(49, 70, 194);
            lblFechaIni.Top = label2.Bottom + 20;
            lblFechaIni.Left = 120;

            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(49, 70, 194);
            label3.Top = lblFechaIni.Top;
            label3.Left = lblFechaIni.Right + 90;

            lblMontoIniVal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMontoIniVal.ForeColor = Color.FromArgb(49, 70, 194);
            lblMontoIniVal.Top = lblFechaIni.Top;
            lblMontoIniVal.Left = label3.Right + 10;

            // --- Sección ventas ---
            Label lblVentas = new Label();
            lblVentas.Text = "Ventas del turno";
            lblVentas.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblVentas.ForeColor = Color.FromArgb(44, 62, 130);
            lblVentas.AutoSize = true;
            lblVentas.Top = lblFechaIni.Bottom + 35;
            lblVentas.Left = lblFechaIni.Left;
            this.Controls.Add(lblVentas);

            // --- Métodos de pago ---
            int ventaLeft = lblFechaIni.Left, ventaTop = lblVentas.Bottom + 16, ventaGap = 140;

            lblEfectivo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblEfectivo.Top = ventaTop;
            lblEfectivo.Left = ventaLeft;

            lblTransferencia.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTransferencia.Top = ventaTop;
            lblTransferencia.Left = ventaLeft + ventaGap;

            lblTarjeta.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTarjeta.Top = ventaTop;
            lblTarjeta.Left = ventaLeft + 2 * ventaGap;

            // --- Totales ---
            lblTotalVentas.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTotalVentas.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotalVentas.Top = lblEfectivo.Bottom + 24;
            lblTotalVentas.Left = ventaLeft;

            lblMontoFinal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblMontoFinal.ForeColor = Color.FromArgb(37, 150, 97);
            lblMontoFinal.Top = lblTotalVentas.Bottom + 18;
            lblMontoFinal.Left = ventaLeft;

            // --- Botón PDF ---
            btnGenerarPDF.Text = "Guardar PDF";
            btnGenerarPDF.Width = 150;
            btnGenerarPDF.Height = 42;
            btnGenerarPDF.Top = lblMontoFinal.Top - 6;
            btnGenerarPDF.Left = lblMontoFinal.Right + 50;
            btnGenerarPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGenerarPDF.BackColor = Color.FromArgb(52, 152, 219);
            btnGenerarPDF.ForeColor = Color.White;
            btnGenerarPDF.FlatStyle = FlatStyle.Flat;
            btnGenerarPDF.FlatAppearance.BorderSize = 0;
            btnGenerarPDF.Cursor = Cursors.Hand;
            btnGenerarPDF.MouseEnter += (s, e) => btnGenerarPDF.BackColor = ControlPaint.Dark(Color.FromArgb(52, 152, 219));
            btnGenerarPDF.MouseLeave += (s, e) => btnGenerarPDF.BackColor = Color.FromArgb(52, 152, 219);

            // --- Botones principales ---
            Button[] btns = { btnGuardarCierre, btnCancelarCierre, btnGenerarPDF };
            string[] texts = { "Cerrar Turno", "Cancelar", "Guardar PDF" };
            Color[] colors = {
                Color.FromArgb(36, 182, 95),   // Verde
                Color.FromArgb(190, 80, 78),   // Rojo
                Color.FromArgb(52, 152, 219)   // Azul
            };
            int btnWidth = 140, btnHeight = 42, gap = 30;
            int btnsTop = btnGenerarPDF.Bottom + 50;
            int btnsLeft = ventaLeft;

            for (int i = 0; i < btns.Length; i++)
            {
                Button btn = btns[i];
                btn.Text = texts[i];
                btn.Width = btnWidth;
                btn.Height = btnHeight;
                btn.Top = btnsTop;
                btn.Left = btnsLeft + i * (btnWidth + gap);
                btn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                btn.BackColor = colors[i];
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
                //btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Dark(colors[i]);
                //btn.MouseLeave += (s, e) => btn.BackColor = colors[i];
            }
        }

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
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay turno abierto");
                    this.Close();
                    return;
                }
                turnoAbierto = dt.Rows[0];
            }

            lblFechaIni.Text = $"Fecha inicio: {((DateTime)turnoAbierto["FechaInicio"]).ToString("dd/MM/yyyy HH:mm")}";
            lblMontoIniVal.Text = $"Monto inicial: {turnoAbierto["MontoInicial"]:C2}";

            CalcularVentasPorMetodoPago();
        }

        private void btnGuardarCierre_Click(object sender, EventArgs e)
        {
            // Extrae el monto final
            decimal montoFinal = 0;
            if (lblMontoFinal.Text.Contains(":"))
            {
                string[] parts = lblMontoFinal.Text.Split(':');
                if (parts.Length > 1)
                    decimal.TryParse(parts[1].Replace("$", "").Trim(), out montoFinal);
            }

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
                    GROUP BY mp.Nombre", conn))
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
            lblTotalVentas.Text = $"Total de ventas: {totalVentas:C2}";

            decimal montoInicial = Convert.ToDecimal(turnoAbierto["MontoInicial"]);

            decimal montoFinal = totalVentas + montoInicial;
            lblMontoFinal.Text = $"Monto Final en Caja: {montoFinal:C2}";
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

                        doc.Add(new Paragraph("Cierre de Turno - PlatyPlus").SetFontSize(16));
                        doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}"));
                        doc.Add(new Paragraph($"Turno ID: {turnoAbierto["IdTurno"]}"));
                        doc.Add(new Paragraph($"Cajero: {turnoAbierto["NombreCajero"]}"));
                        doc.Add(new Paragraph("-------------------------------------------------"));

                        doc.Add(new Paragraph(lblEfectivo.Text));
                        doc.Add(new Paragraph(lblTransferencia.Text));
                        doc.Add(new Paragraph(lblTarjeta.Text));
                        doc.Add(new Paragraph("-------------------------------------------------"));

                        doc.Add(new Paragraph(lblTotalVentas.Text));
                        doc.Add(new Paragraph(lblMontoFinal.Text));
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
