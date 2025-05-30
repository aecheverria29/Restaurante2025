namespace SistemaRestaurante.Forms
{
    partial class NuevoPedidoForm
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
            this.cbMesa = new System.Windows.Forms.ComboBox();
            this.cbTipoConsumo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregarPlato = new System.Windows.Forms.Button();
            this.cbPlato = new System.Windows.Forms.ComboBox();
            this.dgvDetalleTemp = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnGuardarPedido = new System.Windows.Forms.Button();
            this.txtJustificacion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos Generales:";
            // 
            // cbMesa
            // 
            this.cbMesa.FormattingEnabled = true;
            this.cbMesa.Location = new System.Drawing.Point(117, 61);
            this.cbMesa.Name = "cbMesa";
            this.cbMesa.Size = new System.Drawing.Size(121, 21);
            this.cbMesa.TabIndex = 1;
            // 
            // cbTipoConsumo
            // 
            this.cbTipoConsumo.FormattingEnabled = true;
            this.cbTipoConsumo.Location = new System.Drawing.Point(117, 34);
            this.cbTipoConsumo.Name = "cbTipoConsumo";
            this.cbTipoConsumo.Size = new System.Drawing.Size(121, 21);
            this.cbTipoConsumo.TabIndex = 2;
            this.cbTipoConsumo.SelectedIndexChanged += new System.EventHandler(this.cbTipoConsumo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione mesa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Consumo:";
            // 
            // btnAgregarPlato
            // 
            this.btnAgregarPlato.Location = new System.Drawing.Point(258, 118);
            this.btnAgregarPlato.Name = "btnAgregarPlato";
            this.btnAgregarPlato.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarPlato.TabIndex = 5;
            this.btnAgregarPlato.Text = "Agregar plato";
            this.btnAgregarPlato.UseVisualStyleBackColor = true;
            this.btnAgregarPlato.Click += new System.EventHandler(this.btnAgregarPlato_Click);
            // 
            // cbPlato
            // 
            this.cbPlato.FormattingEnabled = true;
            this.cbPlato.Location = new System.Drawing.Point(117, 120);
            this.cbPlato.Name = "cbPlato";
            this.cbPlato.Size = new System.Drawing.Size(121, 21);
            this.cbPlato.TabIndex = 6;
            // 
            // dgvDetalleTemp
            // 
            this.dgvDetalleTemp.AllowUserToAddRows = false;
            this.dgvDetalleTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTemp.Location = new System.Drawing.Point(26, 205);
            this.dgvDetalleTemp.Name = "dgvDetalleTemp";
            this.dgvDetalleTemp.ReadOnly = true;
            this.dgvDetalleTemp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleTemp.Size = new System.Drawing.Size(532, 150);
            this.dgvDetalleTemp.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Plato:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cantidad:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Comentario:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(117, 151);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(71, 20);
            this.txtCantidad.TabIndex = 11;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(117, 179);
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(451, 20);
            this.txtComentario.TabIndex = 12;
            // 
            // btnGuardarPedido
            // 
            this.btnGuardarPedido.Location = new System.Drawing.Point(26, 373);
            this.btnGuardarPedido.Name = "btnGuardarPedido";
            this.btnGuardarPedido.Size = new System.Drawing.Size(105, 23);
            this.btnGuardarPedido.TabIndex = 13;
            this.btnGuardarPedido.Text = "Guardar pedido";
            this.btnGuardarPedido.UseVisualStyleBackColor = true;
            this.btnGuardarPedido.Click += new System.EventHandler(this.btnGuardarPedido_Click);
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(117, 86);
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(121, 20);
            this.txtJustificacion.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Justificacion:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(146, 373);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // NuevoPedidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 426);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.btnGuardarPedido);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDetalleTemp);
            this.Controls.Add(this.cbPlato);
            this.Controls.Add(this.btnAgregarPlato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTipoConsumo);
            this.Controls.Add(this.cbMesa);
            this.Controls.Add(this.label1);
            this.Name = "NuevoPedidoForm";
            this.Text = "NuevoPedidoForm";
            this.Load += new System.EventHandler(this.NuevoPedidoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMesa;
        private System.Windows.Forms.ComboBox cbTipoConsumo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregarPlato;
        private System.Windows.Forms.ComboBox cbPlato;
        private System.Windows.Forms.DataGridView dgvDetalleTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnGuardarPedido;
        private System.Windows.Forms.TextBox txtJustificacion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancelar;
    }
}