namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    partial class MovimientoInventarioForm
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
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtJustificacion = new System.Windows.Forms.TextBox();
            this.rbEntrada = new System.Windows.Forms.RadioButton();
            this.rbSalida = new System.Windows.Forms.RadioButton();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFiltroInsumo = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // cbInsumo
            // 
            this.cbInsumo.FormattingEnabled = true;
            this.cbInsumo.Location = new System.Drawing.Point(133, 20);
            this.cbInsumo.Margin = new System.Windows.Forms.Padding(2);
            this.cbInsumo.Name = "cbInsumo";
            this.cbInsumo.Size = new System.Drawing.Size(92, 21);
            this.cbInsumo.TabIndex = 0;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(172, 60);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 20);
            this.txtCantidad.TabIndex = 1;
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(389, 65);
            this.txtJustificacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(76, 20);
            this.txtJustificacion.TabIndex = 2;
            // 
            // rbEntrada
            // 
            this.rbEntrada.AutoSize = true;
            this.rbEntrada.Location = new System.Drawing.Point(244, 24);
            this.rbEntrada.Margin = new System.Windows.Forms.Padding(2);
            this.rbEntrada.Name = "rbEntrada";
            this.rbEntrada.Size = new System.Drawing.Size(138, 17);
            this.rbEntrada.TabIndex = 3;
            this.rbEntrada.TabStop = true;
            this.rbEntrada.Text = "Movimiento tipo entrada";
            this.rbEntrada.UseVisualStyleBackColor = true;
            // 
            // rbSalida
            // 
            this.rbSalida.AutoSize = true;
            this.rbSalida.Location = new System.Drawing.Point(389, 24);
            this.rbSalida.Margin = new System.Windows.Forms.Padding(2);
            this.rbSalida.Name = "rbSalida";
            this.rbSalida.Size = new System.Drawing.Size(129, 17);
            this.rbSalida.TabIndex = 4;
            this.rbSalida.TabStop = true;
            this.rbSalida.Text = "Movimiento tipo salida";
            this.rbSalida.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(425, 138);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(118, 19);
            this.btnRegistrar.TabIndex = 5;
            this.btnRegistrar.Text = "Guardar movimiento";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(40, 138);
            this.dgvMovimientos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.RowHeadersWidth = 51;
            this.dgvMovimientos.RowTemplate.Height = 24;
            this.dgvMovimientos.Size = new System.Drawing.Size(337, 122);
            this.dgvMovimientos.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seleccionar insumo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad que entra o sale";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Motivo del movimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Historial de movimientos por insumo o fecha";
            // 
            // cbFiltroInsumo
            // 
            this.cbFiltroInsumo.FormattingEnabled = true;
            this.cbFiltroInsumo.Location = new System.Drawing.Point(44, 286);
            this.cbFiltroInsumo.Name = "cbFiltroInsumo";
            this.cbFiltroInsumo.Size = new System.Drawing.Size(121, 21);
            this.cbFiltroInsumo.TabIndex = 11;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(197, 283);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrar.TabIndex = 12;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(465, 283);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 13;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // MovimientoInventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbFiltroInsumo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMovimientos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.rbSalida);
            this.Controls.Add(this.rbEntrada);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cbInsumo);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MovimientoInventarioForm";
            this.Text = "MovimientoInventarioForm";
            this.Load += new System.EventHandler(this.MovimientoInventarioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtJustificacion;
        private System.Windows.Forms.RadioButton rbEntrada;
        private System.Windows.Forms.RadioButton rbSalida;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFiltroInsumo;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnRegresar;
    }
}