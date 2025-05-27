using SistemaRestaurante.Services;
using SistemaRestaurante.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Drawing;
using System.IO;


namespace SistemaRestaurante.Forms
{
    public partial class EmitirTicketForm : Form
    {
        private int idPedido;
        private string contenidoTicket = "";
        private int idTurno;
        public EmitirTicketForm(int id, int turnoId = 1)
        {
            InitializeComponent();
            idPedido = id;
            idTurno = turnoId;
            this.Load += EmitirTicketForm_Load;
        }
        private void EmitirTicketForm_Load(object sender, EventArgs e)
        {
            CargarDetallePedido();
            CargarMetodosPago();
        }
        private void CargarDetallePedido()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    SELECT p.Nombre, dp.Cantidad, dp.PrecioUnitario, dp.SubTotal, dp.Comentarios
                    FROM DetallePedido dp
                    INNER JOIN Platos p ON dp.IdPlato = p.IdPlato
                    WHERE dp.IdPedido = @id", conn);
                cmd.Parameters.AddWithValue("id", idPedido);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDetalle.DataSource = dt;

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["Subtotal"]);
                }
                lblTotal.Text = $"Total a pagar: ${total:F2}";
            }
        }
        private void CargarMetodosPago()
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdMetodoPago, Nombre FROM MetodosPago", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMetodoPago.DataSource = dt;
                cbMetodoPago.DisplayMember = "Nombre";
                cbMetodoPago.ValueMember = "IdMetodoPago";
            }
        }
        private string GenerarNumeroControl(SqlConnection conn, SqlTransaction trans)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) + 1 FROM Facturas", conn, trans);
            int correlativo = (int)cmd.ExecuteScalar();
            return correlativo.ToString("D6");
        }

        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if (cbMetodoPago.SelectedIndex < 0)
            {
                MessageBox.Show("Selecciona un método de pago.");
                return;
            }

            decimal total = 0;
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                total += Convert.ToDecimal(row.Cells["SubTotal"].Value);
            }

            using (SqlConnection conn = DBConnection.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    string numeroControl = GenerarNumeroControl(conn, trans);

                    int idTurnoActual;
                    using (var cmdTurno = new SqlCommand(
                           "SELECT TOP 1 IdTurno FROM Turnos WHERE Estado = 'Abierto' ORDER BY FechaInicio DESC",
                           conn, trans))
                    {
                        object turnoObj = cmdTurno.ExecuteScalar();
                        if (turnoObj == null)
                            throw new InvalidOperationException("No hay ningún turno abierto.");
                        idTurnoActual = Convert.ToInt32(turnoObj);
                    }

                    SqlCommand cmdCheck = new SqlCommand("SELECT Pagado FROM Facturas WHERE IdPedido = @id", conn, trans);
                    cmdCheck.Parameters.AddWithValue("@id", idPedido);
                    var result = cmdCheck.ExecuteScalar();
                    if (result != null && Convert.ToBoolean(result))
                    {
                        MessageBox.Show("Este pedido ya fue pagado y facturado.");
                        trans.Rollback();
                        return;
                    }

                    SqlCommand cmd = new SqlCommand(@"
                        INSERT INTO Facturas (IdPedido, Total, FechaEmision, NumeroControl, Serie, XML, EstadoEnvio, IdMetodoPago, IdTurno, Pagado)
                        VALUES (@pedido, @total, GETDATE(), @control, @serie, @xml, @estado, @metodo, @turno, 1)", conn, trans
                    );

                    cmd.Parameters.Add("@pedido", SqlDbType.Int).Value = idPedido;
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@control", numeroControl);
                    cmd.Parameters.AddWithValue("@serie", "T001");
                    cmd.Parameters.AddWithValue("@xml", "<xml>...</xml>");
                    cmd.Parameters.AddWithValue("@estado", "Enviado");
                    cmd.Parameters.AddWithValue("@metodo", cbMetodoPago.SelectedValue);
                    cmd.Parameters.AddWithValue("@turno", idTurnoActual);

                    cmd.ExecuteNonQuery();


                    SqlCommand cmdMesa = new SqlCommand(@"
                    UPDATE Mesas SET IdEstadoMesa = 1 
                    WHERE IdMesa = (SELECT IdMesa FROM Pedidos WHERE IdPedido = @id)", conn, trans);
                    cmdMesa.Parameters.AddWithValue("@id", idPedido);
                    cmdMesa.ExecuteNonQuery();

                    trans.Commit();
                    //Para ejecutar la impresion del ticket
                    //GenerarContenidoTicket();
                    //ImprimirTicket(); 
                    MessageBox.Show("Ticket emitido correctamente.");

                    var resp = MessageBox.Show(
                         "¿Deseas guardar el ticket en PDF?",
                         "Guardar PDF",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);

                    if (resp == DialogResult.Yes)
                    {
                        bool ok = GuardarPDFConIText();
                        MessageBox.Show(ok
                            ? "PDF generado correctamente."
                            : "Falló la generación del PDF.");
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error al emitir ticket: " + ex.Message);
                }

            }
        }

        public void GenerarContenidoTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("  SOFTWARE PLATYPLUS");
            sb.AppendLine("  Ticket de Venta");
            sb.AppendLine("------------------------------");
            sb.AppendLine("Pedido #: " + idPedido);
            sb.AppendLine("Fecha: " + DateTime.Now.ToShortDateString());
            sb.AppendLine("Hora: " + DateTime.Now.ToShortTimeString());
            sb.AppendLine("------------------------------");
            sb.AppendLine("Producto        Cant.   Subtotal");

            decimal total = 0;

            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["Nombre"].Value != null &&
                    row.Cells["Cantidad"].Value != null &&
                    row.Cells["Subtotal"].Value != null)
                {
                    string nombre = row.Cells["Nombre"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);

                    total += subtotal;
                    sb.AppendLine($"{nombre.PadRight(15).Substring(0, 15)} {cantidad.ToString().PadLeft(2)}   {subtotal.ToString("0.00").PadLeft(6)}");
                }
            }

            sb.AppendLine("------------------------------");
            sb.AppendLine($"TOTAL:               ${total.ToString("0.00")}");
            sb.AppendLine("------------------------------");
            sb.AppendLine("¡Gracias por su compra!");
            sb.AppendLine("PlatyPlus © 2025");

            contenidoTicket = sb.ToString();
        }

        public void ImprimirTicket()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, ev) =>
            {
                Font font = new Font("Consolas", 10);
                ev.Graphics.DrawString(contenidoTicket, font, Brushes.Black, new RectangleF(0, 0, pd.DefaultPageSettings.PrintableArea.Width, pd.DefaultPageSettings.PrintableArea.Height));
            };

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de cancelar esta operación?",
                "Cancelar emisión de ticket",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                MainForm main = this.ParentForm as MainForm;
                if (main != null)
                {
                    this.Close();
                    main.CargarFormulario(new FacturacionForm(main));
                }
                else
                {
                    this.Close();
                }
            }
        }

        private bool GuardarPDFConIText()
        {
            
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter   = "Archivos PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Ticket_{idPedido}.pdf";

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

                        doc.Add(new Paragraph("SOFTWARE PLATYPLUS").SetFontSize(14));
                        doc.Add(new Paragraph("Ticket de Venta").SetFontSize(12));
                        doc.Add(new Paragraph("-------------------------------"));
                        doc.Add(new Paragraph($"Pedido #: {idPedido}"));
                        doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}"));
                        doc.Add(new Paragraph($"Hora:  {DateTime.Now:HH:mm}"));
                        doc.Add(new Paragraph("-------------------------------"));

                        decimal total = 0;
                        foreach (DataGridViewRow row in dgvDetalle.Rows)
                        {
                            if (row.IsNewRow)
                                continue;

                            string nombre = row.Cells["Nombre"].Value?.ToString() ?? "";
                            int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            decimal subtotal = Convert.ToDecimal(row.Cells["SubTotal"].Value);
                            total += subtotal;
                            doc.Add(new Paragraph($"{nombre} x{cantidad} - ${subtotal:F2}"));
                        }

                        doc.Add(new Paragraph("-------------------------------"));
                        doc.Add(new Paragraph($"TOTAL: ${total:F2}"));
                        doc.Add(new Paragraph("-------------------------------"));
                        doc.Add(new Paragraph("¡Gracias por su compra!"));
                        doc.Add(new Paragraph("PlatyPlus © 2025"));

                        
                    }
                    Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el PDF:\n" + ex.Message);
                    return false;
                }
            }
        }

    }
}