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
            this.label1 = new System.Windows.Forms.Label();
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
            this.lblFechaIni.Location = new System.Drawing.Point(194, 57);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(81, 13);
            this.lblFechaIni.TabIndex = 0;
            this.lblFechaIni.Text = "Fecha inicio: [–]";
            // 
            // lblMontoIniVal
            // 
            this.lblMontoIniVal.AutoSize = true;
            this.lblMontoIniVal.Location = new System.Drawing.Point(466, 57);
            this.lblMontoIniVal.Name = "lblMontoIniVal";
            this.lblMontoIniVal.Size = new System.Drawing.Size(83, 13);
            this.lblMontoIniVal.TabIndex = 1;
            this.lblMontoIniVal.Text = "Monto inicial: [–]";
            // 
            // lblMontoFinal
            // 
            this.lblMontoFinal.AutoSize = true;
            this.lblMontoFinal.Location = new System.Drawing.Point(191, 222);
            this.lblMontoFinal.Name = "lblMontoFinal";
            this.lblMontoFinal.Size = new System.Drawing.Size(100, 13);
            this.lblMontoFinal.TabIndex = 4;
            this.lblMontoFinal.Text = "Monto final en caja:";
            // 
            // btnGuardarCierre
            // 
            this.btnGuardarCierre.Location = new System.Drawing.Point(265, 299);
            this.btnGuardarCierre.Name = "btnGuardarCierre";
            this.btnGuardarCierre.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCierre.TabIndex = 6;
            this.btnGuardarCierre.Text = "Cerrar Turno";
            this.btnGuardarCierre.UseVisualStyleBackColor = true;
            this.btnGuardarCierre.Click += new System.EventHandler(this.btnGuardarCierre_Click);
            // 
            // btnCancelarCierre
            // 
            this.btnCancelarCierre.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelarCierre.Location = new System.Drawing.Point(346, 299);
            this.btnCancelarCierre.Name = "btnCancelarCierre";
            this.btnCancelarCierre.Size = new System.Drawing.Size(75, 23);
            this.btnCancelarCierre.TabIndex = 7;
            this.btnCancelarCierre.Text = "Cancelar";
            this.btnCancelarCierre.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Corte de caja";
            // 
            // lblEfectivo
            // 
            this.lblEfectivo.AutoSize = true;
            this.lblEfectivo.Location = new System.Drawing.Point(194, 128);
            this.lblEfectivo.Name = "lblEfectivo";
            this.lblEfectivo.Size = new System.Drawing.Size(49, 13);
            this.lblEfectivo.TabIndex = 9;
            this.lblEfectivo.Text = "Efectivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ventas del turno";
            // 
            // lblTransferencia
            // 
            this.lblTransferencia.AutoSize = true;
            this.lblTransferencia.Location = new System.Drawing.Point(299, 128);
            this.lblTransferencia.Name = "lblTransferencia";
            this.lblTransferencia.Size = new System.Drawing.Size(75, 13);
            this.lblTransferencia.TabIndex = 11;
            this.lblTransferencia.Text = "Transferencia:";
            // 
            // lblTarjeta
            // 
            this.lblTarjeta.AutoSize = true;
            this.lblTarjeta.Location = new System.Drawing.Point(441, 128);
            this.lblTarjeta.Name = "lblTarjeta";
            this.lblTarjeta.Size = new System.Drawing.Size(43, 13);
            this.lblTarjeta.TabIndex = 12;
            this.lblTarjeta.Text = "Tarjeta:";
            // 
            // lblTotalVentas
            // 
            this.lblTotalVentas.AutoSize = true;
            this.lblTotalVentas.Location = new System.Drawing.Point(191, 175);
            this.lblTotalVentas.Name = "lblTotalVentas";
            this.lblTotalVentas.Size = new System.Drawing.Size(84, 13);
            this.lblTotalVentas.TabIndex = 13;
            this.lblTotalVentas.Text = "Total de ventas:";
            // 
            // btnGenerarPDF
            // 
            this.btnGenerarPDF.Location = new System.Drawing.Point(397, 217);
            this.btnGenerarPDF.Name = "btnGenerarPDF";
            this.btnGenerarPDF.Size = new System.Drawing.Size(90, 23);
            this.btnGenerarPDF.TabIndex = 14;
            this.btnGenerarPDF.Text = "Guardar PDF";
            this.btnGenerarPDF.UseVisualStyleBackColor = true;
            this.btnGenerarPDF.Click += new System.EventHandler(this.btnGenerarPDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(377, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Monto inicial: [–]";
            // 
            // FrmTurnoCierre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenerarPDF);
            this.Controls.Add(this.lblTotalVentas);
            this.Controls.Add(this.lblTarjeta);
            this.Controls.Add(this.lblTransferencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEfectivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelarCierre);
            this.Controls.Add(this.btnGuardarCierre);
            this.Controls.Add(this.lblMontoFinal);
            this.Controls.Add(this.lblMontoIniVal);
            this.Controls.Add(this.lblFechaIni);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEfectivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTransferencia;
        private System.Windows.Forms.Label lblTarjeta;
        private System.Windows.Forms.Label lblTotalVentas;
        private System.Windows.Forms.Button btnGenerarPDF;
        private System.Windows.Forms.Label label3;
    }
}