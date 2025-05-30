namespace SistemaRestaurante.Forms.Modulo_CatePlatos
{
    partial class RecetasForm
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
            this.cbPlato = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbInsumo = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.txtBuscarPlato = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPlato
            // 
            this.cbPlato.FormattingEnabled = true;
            this.cbPlato.Location = new System.Drawing.Point(316, 51);
            this.cbPlato.Name = "cbPlato";
            this.cbPlato.Size = new System.Drawing.Size(121, 21);
            this.cbPlato.TabIndex = 0;
            this.cbPlato.SelectedIndexChanged += new System.EventHandler(this.cbPlato_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Busca/Selecciona el plato al que vas a asignar receta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "\tSeleccionar el insumo";
            // 
            // cbInsumo
            // 
            this.cbInsumo.FormattingEnabled = true;
            this.cbInsumo.Location = new System.Drawing.Point(316, 78);
            this.cbInsumo.Name = "cbInsumo";
            this.cbInsumo.Size = new System.Drawing.Size(121, 21);
            this.cbInsumo.TabIndex = 3;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(316, 105);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 20);
            this.txtCantidad.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "\tCantidad necesaria del insumo";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(354, 149);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(440, 149);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(530, 149);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 8;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // dgvReceta
            // 
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Location = new System.Drawing.Point(38, 187);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.Size = new System.Drawing.Size(567, 150);
            this.dgvReceta.TabIndex = 9;
            // 
            // txtBuscarPlato
            // 
            this.txtBuscarPlato.Location = new System.Drawing.Point(316, 21);
            this.txtBuscarPlato.Name = "txtBuscarPlato";
            this.txtBuscarPlato.Size = new System.Drawing.Size(289, 20);
            this.txtBuscarPlato.TabIndex = 10;
            this.txtBuscarPlato.TextChanged += new System.EventHandler(this.txtBuscarPlato_TextChanged);
            // 
            // RecetasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 382);
            this.Controls.Add(this.txtBuscarPlato);
            this.Controls.Add(this.dgvReceta);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cbInsumo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPlato);
            this.Name = "RecetasForm";
            this.Text = "RecetasForm";
            this.Load += new System.EventHandler(this.RecetasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPlato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbInsumo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.TextBox txtBuscarPlato;
    }
}