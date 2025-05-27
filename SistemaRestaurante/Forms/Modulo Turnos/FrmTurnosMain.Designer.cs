namespace SistemaRestaurante.Forms.Modulo_Turnos
{
    partial class FrmTurnosMain
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
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.btnAbrirTurno = new System.Windows.Forms.Button();
            this.btnCerrarTurno = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Turnos";
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(118, 58);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.Size = new System.Drawing.Size(444, 150);
            this.dgvTurnos.TabIndex = 1;
            this.dgvTurnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnos_CellContentClick);
            // 
            // btnAbrirTurno
            // 
            this.btnAbrirTurno.Location = new System.Drawing.Point(156, 234);
            this.btnAbrirTurno.Name = "btnAbrirTurno";
            this.btnAbrirTurno.Size = new System.Drawing.Size(75, 23);
            this.btnAbrirTurno.TabIndex = 2;
            this.btnAbrirTurno.Text = "Abrir Turno";
            this.btnAbrirTurno.UseVisualStyleBackColor = true;
            this.btnAbrirTurno.Click += new System.EventHandler(this.btnAbrirTurno_Click);
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.Location = new System.Drawing.Point(323, 233);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Size = new System.Drawing.Size(75, 23);
            this.btnCerrarTurno.TabIndex = 3;
            this.btnCerrarTurno.Text = "Cerrar Turno";
            this.btnCerrarTurno.UseVisualStyleBackColor = true;
            this.btnCerrarTurno.Click += new System.EventHandler(this.btnCerrarTurno_Click);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(198, 291);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(70, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuario: [-]";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(198, 315);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(96, 13);
            this.lblEstado.TabIndex = 5;
            this.lblEstado.Text = "Turno Abierto: -";
            // 
            // FrmTurnosMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnCerrarTurno);
            this.Controls.Add(this.btnAbrirTurno);
            this.Controls.Add(this.dgvTurnos);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTurnosMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTurnosMain";
            this.Load += new System.EventHandler(this.FrmTurnosMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnAbrirTurno;
        private System.Windows.Forms.Button btnCerrarTurno;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEstado;
    }
}