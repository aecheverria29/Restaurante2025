namespace SistemaRestaurante.Forms
{
    partial class SeleccionarTipoDocumentoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué tipo de documento desea emitir?";
            // 
            // btnTicket
            // 
            this.btnTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.Location = new System.Drawing.Point(163, 87);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(182, 55);
            this.btnTicket.TabIndex = 1;
            this.btnTicket.Text = "Ticket";
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFactura.Location = new System.Drawing.Point(374, 87);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(171, 55);
            this.btnFactura.TabIndex = 2;
            this.btnFactura.Text = "Factura";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(327, 164);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // SeleccionarTipoDocumentoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnFactura);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.label1);
            this.Name = "SeleccionarTipoDocumentoForm";
            this.Text = "SeleccionarTipoDocumentoForm";
            this.Load += new System.EventHandler(this.SeleccionarTipoDocumentoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.Button btnSalir;
    }
}