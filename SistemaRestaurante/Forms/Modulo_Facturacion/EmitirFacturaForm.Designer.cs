namespace SistemaRestaurante.Forms
{
    partial class EmitirFacturaForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtNIT = new System.Windows.Forms.TextBox();
            this.txtNRC = new System.Windows.Forms.TextBox();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtNumControl = new System.Windows.Forms.TextBox();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NIT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "NRC (Opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Metodo pago";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Serie Fiscal";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Control Fiscal";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ruta XML o contenido";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(64, 373);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(126, 23);
            this.btnFacturar.TabIndex = 7;
            this.btnFacturar.Text = "Ejecutar Facturacion";
            this.btnFacturar.UseVisualStyleBackColor = true;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(160, 35);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCliente.TabIndex = 8;
            // 
            // txtNIT
            // 
            this.txtNIT.Location = new System.Drawing.Point(160, 73);
            this.txtNIT.Name = "txtNIT";
            this.txtNIT.Size = new System.Drawing.Size(100, 20);
            this.txtNIT.TabIndex = 9;
            // 
            // txtNRC
            // 
            this.txtNRC.Location = new System.Drawing.Point(160, 101);
            this.txtNRC.Name = "txtNRC";
            this.txtNRC.Size = new System.Drawing.Size(100, 20);
            this.txtNRC.TabIndex = 10;
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Location = new System.Drawing.Point(160, 189);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(121, 21);
            this.cbMetodoPago.TabIndex = 11;
            this.cbMetodoPago.SelectedIndexChanged += new System.EventHandler(this.cbMetodoPago_SelectedIndexChanged);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(160, 233);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 20);
            this.txtSerie.TabIndex = 12;
            this.txtSerie.TextChanged += new System.EventHandler(this.txtSerie_TextChanged);
            // 
            // txtNumControl
            // 
            this.txtNumControl.Location = new System.Drawing.Point(160, 282);
            this.txtNumControl.Name = "txtNumControl";
            this.txtNumControl.Size = new System.Drawing.Size(100, 20);
            this.txtNumControl.TabIndex = 13;
            this.txtNumControl.TextChanged += new System.EventHandler(this.txtNumControl_TextChanged);
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(181, 318);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(100, 20);
            this.txtXML.TabIndex = 14;
            this.txtXML.TextChanged += new System.EventHandler(this.txtXML_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(286, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(103, 23);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar Cliente";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(61, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Correo electronico";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(160, 147);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(100, 20);
            this.txtCorreo.TabIndex = 17;
            // 
            // EmitirFacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 450);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.txtNumControl);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.txtNRC);
            this.Controls.Add(this.txtNIT);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EmitirFacturaForm";
            this.Text = "EmitirFacturaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.TextBox txtNIT;
        private System.Windows.Forms.TextBox txtNRC;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtNumControl;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCorreo;
    }
}