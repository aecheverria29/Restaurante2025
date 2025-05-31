namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    partial class FrmTurnoCierre
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFechaIni = new System.Windows.Forms.Label();
            this.lblMontoIniVal = new System.Windows.Forms.Label();
            this.lblMontoFinal = new System.Windows.Forms.Label();
            this.btnGuardarCierre = new System.Windows.Forms.Button();
            this.btnCancelarCierre = new System.Windows.Forms.Button();
            this.lblEfectivo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTransferencia = new System.Windows.Forms.Label();
            this.lblTarjeta = new System.Windows.Forms.Label();
            this.lblTotalVentas = new System.Windows.Forms.Label();
            this.btnGenerarPDF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Location = new System.Drawing.Point(259, 70);
            this.lblFechaIni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(98, 16);
            this.lblFechaIni.TabIndex = 0;
            this.lblFechaIni.Text = "Fecha inicio: [–]";
            // 
            // lblMontoIniVal
            // 
            this.lblMontoIniVal.AutoSize = true;
            this.lblMontoIniVal.Location = new System.Drawing.Point(621, 70);
            this.lblMontoIniVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoIniVal.Name = "lblMontoIniVal";
            this.lblMontoIniVal.Size = new System.Drawing.Size(100, 16);
            this.lblMontoIniVal.TabIndex = 1;
            this.lblMontoIniVal.Text = "Monto inicial: [–]";
            // 
            // lblMontoFinal
            // 
            this.lblMontoFinal.AutoSize = true;
            this.lblMontoFinal.Location = new System.Drawing.Point(255, 273);
            this.lblMontoFinal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoFinal.Name = "lblMontoFinal";
            this.lblMontoFinal.Size = new System.Drawing.Size(121, 16);
            this.lblMontoFinal.TabIndex = 4;
            this.lblMontoFinal.Text = "Monto final en caja:";
            // 
            // btnGuardarCierre
            // 
            this.btnGuardarCierre.Location = new System.Drawing.Point(353, 368);
            this.btnGuardarCierre.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCierre.Name = "btnGuardarCierre";
            this.btnGuardarCierre.Size = new System.Drawing.Size(100, 28);
            this.btnGuardarCierre.TabIndex = 6;
            this.btnGuardarCierre.Text = "Cerrar Turno";
            this.btnGuardarCierre.UseVisualStyleBackColor = true;
            this.btnGuardarCierre.Click += new System.EventHandler(this.btnGuardarCierre_Click);
            // 
            // btnCancelarCierre
            // 
            this.btnCancelarCierre.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCierre.Location = new System.Drawing.Point(461, 368);
            this.btnCancelarCierre.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarCierre.Name = "btnCancelarCierre";
            this.btnCancelarCierre.Size = new System.Drawing.Size(100, 28);
            this.btnCancelarCierre.TabIndex = 7;
            this.btnCancelarCierre.Text = "Cancelar";
            this.btnCancelarCierre.UseVisualStyleBackColor = true;
            this.btnCancelarCierre.Click += new System.EventHandler(this.btnCancelarCierre_Click);
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(259, 158);
            this.lblEfectivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(58, 16);
            this.lblEfectivo.TabIndex = 9;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(259, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ventas del turno";
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Location = new System.Drawing.Point(399, 158);
            this.lblTransferencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(93, 16);
            this.lblTransferencia.TabIndex = 11;
            this.lblTransferencia.Text = "Transferencia:";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(588, 158);
            this.lblTarjeta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(53, 16);
            this.lblTarjeta.TabIndex = 12;
            this.lblTarjeta.Text = "Tarjeta:";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Location = new System.Drawing.Point(255, 215);
            this.lblTotalVentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(103, 16);
            this.lblTotalVentas.TabIndex = 13;
            this.lblTotalVentas.Text = "Total de ventas:";
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Location = new System.Drawing.Point(529, 267);
            this.btnGenerarPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(120, 28);
            this.btnGenerarPDF.TabIndex = 14;
            this.btnGenerarPDF.Text = "Guardar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Monto inicial: [–]";
            // 
            // FrmTurnoCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblTransferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.btnCancelarCierre);
            this.Controls.Add(this.btnGuardarCierre);
            this.Controls.Add(this.lblMontoFinal);
            this.Controls.Add(this.lblMontoIniVal);
            this.Controls.Add(this.lblFechaIni);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmTurnoCierre";
            this.Text = "FrmTurnoCierre";
            this.Load += new System.EventHandler(this.FrmTurnoCierre_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFechaIni;
        private System.Windows.Forms.Label lblMontoIniVal;
        private System.Windows.Forms.Label lblMontoFinal;
        private System.Windows.Forms.Button btnGuardarCierre;
        private System.Windows.Forms.Button btnCancelarCierre;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Label label3;
    }
}