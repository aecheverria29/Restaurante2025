namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    partial class FrmTurnoApertura
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
            this.lblSelUsuario = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblMontoIni = new System.Windows.Forms.Label();
            this.nudMontoInicial = new System.Windows.Forms.NumericUpDown();
            this.btnGuardarApertura = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Apertura de Turno";
            // 
            // lblSelUsuario
            // 
            this.lblSelUsuario.AutoSize = true;
            this.lblSelUsuario.Location = new System.Drawing.Point(199, 79);
            this.lblSelUsuario.Name = "lblSelUsuario";
            this.lblSelUsuario.Size = new System.Drawing.Size(100, 13);
            this.lblSelUsuario.TabIndex = 2;
            this.lblSelUsuario.Text = "Seleccione usuario:";
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(319, 79);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(121, 21);
            this.cmbUsuarios.TabIndex = 3;
            // 
            // lblMontoIni
            // 
            this.lblMontoIni.AutoSize = true;
            this.lblMontoIni.Location = new System.Drawing.Point(199, 129);
            this.lblMontoIni.Name = "lblMontoIni";
            this.lblMontoIni.Size = new System.Drawing.Size(69, 13);
            this.lblMontoIni.TabIndex = 4;
            this.lblMontoIni.Text = "Monto inicial:";
            // 
            // nudMontoInicial
            // 
            this.nudMontoInicial.DecimalPlaces = 2;
            this.nudMontoInicial.Location = new System.Drawing.Point(319, 122);
            this.nudMontoInicial.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudMontoInicial.Name = "nudMontoInicial";
            this.nudMontoInicial.Size = new System.Drawing.Size(120, 20);
            this.nudMontoInicial.TabIndex = 5;
            // 
            // btnGuardarApertura
            // 
            this.btnGuardarApertura.Location = new System.Drawing.Point(217, 188);
            this.btnGuardarApertura.Name = "btnGuardarApertura";
            this.btnGuardarApertura.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarApertura.TabIndex = 6;
            this.btnGuardarApertura.Text = "Abrir Turno";
            this.btnGuardarApertura.UseVisualStyleBackColor = true;
            this.btnGuardarApertura.Click += new System.EventHandler(this.btnGuardarApertura_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(336, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmTurnoApertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarApertura);
            this.Controls.Add(this.nudMontoInicial);
            this.Controls.Add(this.lblMontoIni);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblSelUsuario);
            this.Controls.Add(this.label1);
            this.Name = "FrmTurnoApertura";
            this.Load += new System.EventHandler(this.FrmTurnoApertura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMontoInicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelUsuario;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Label lblMontoIni;
        private System.Windows.Forms.NumericUpDown nudMontoInicial;
        private System.Windows.Forms.Button btnGuardarApertura;
        private System.Windows.Forms.Button btnCancelar;
    }
}