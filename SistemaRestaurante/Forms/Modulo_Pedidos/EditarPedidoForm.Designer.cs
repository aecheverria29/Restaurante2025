namespace SistemaRestaurante.Forms
{
    partial class EditarPedidoForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMesa = new System.Windows.Forms.ComboBox();
            this.cbTipoConsumo = new System.Windows.Forms.ComboBox();
            this.cbPlato = new System.Windows.Forms.ComboBox();
            this.txtJustificacion = new System.Windows.Forms.TextBox();
            this.txtCantidadEdit = new System.Windows.Forms.TextBox();
            this.txtComentarioEdit = new System.Windows.Forms.TextBox();
            this.btnAgregarPlato = new System.Windows.Forms.Button();
            this.dgvDetalleTemp = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminarPlato = new System.Windows.Forms.Button();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Justificacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Comentario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Plato:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Consumo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Datos Generales:";
            // 
            // cbMesa
            // 
            this.cbMesa.FormattingEnabled = true;
            this.cbMesa.Location = new System.Drawing.Point(102, 31);
            this.cbMesa.Name = "cbMesa";
            this.cbMesa.Size = new System.Drawing.Size(121, 21);
            this.cbMesa.TabIndex = 23;
            // 
            // cbTipoConsumo
            // 
            this.cbTipoConsumo.FormattingEnabled = true;
            this.cbTipoConsumo.Location = new System.Drawing.Point(102, 58);
            this.cbTipoConsumo.Name = "cbTipoConsumo";
            this.cbTipoConsumo.Size = new System.Drawing.Size(121, 21);
            this.cbTipoConsumo.TabIndex = 24;
            // 
            // cbPlato
            // 
            this.cbPlato.FormattingEnabled = true;
            this.cbPlato.Location = new System.Drawing.Point(102, 119);
            this.cbPlato.Name = "cbPlato";
            this.cbPlato.Size = new System.Drawing.Size(121, 21);
            this.cbPlato.TabIndex = 25;
            // 
            // txtJustificacion
            // 
            this.txtJustificacion.Location = new System.Drawing.Point(107, 85);
            this.txtJustificacion.Name = "txtJustificacion";
            this.txtJustificacion.Size = new System.Drawing.Size(100, 20);
            this.txtJustificacion.TabIndex = 26;
            // 
            // txtCantidadEdit
            // 
            this.txtCantidadEdit.Location = new System.Drawing.Point(102, 147);
            this.txtCantidadEdit.Name = "txtCantidadEdit";
            this.txtCantidadEdit.Size = new System.Drawing.Size(121, 20);
            this.txtCantidadEdit.TabIndex = 27;
            // 
            // txtComentarioEdit
            // 
            this.txtComentarioEdit.Location = new System.Drawing.Point(102, 173);
            this.txtComentarioEdit.Name = "txtComentarioEdit";
            this.txtComentarioEdit.Size = new System.Drawing.Size(121, 20);
            this.txtComentarioEdit.TabIndex = 28;
            // 
            // btnAgregarPlato
            // 
            this.btnAgregarPlato.Location = new System.Drawing.Point(48, 221);
            this.btnAgregarPlato.Name = "btnAgregarPlato";
            this.btnAgregarPlato.Size = new System.Drawing.Size(105, 23);
            this.btnAgregarPlato.TabIndex = 29;
            this.btnAgregarPlato.Text = "Agregar Plato";
            this.btnAgregarPlato.UseVisualStyleBackColor = true;
            this.btnAgregarPlato.Click += new System.EventHandler(this.btnAgregarPlato_Click);
            // 
            // dgvDetalleTemp
            // 
            this.dgvDetalleTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleTemp.Location = new System.Drawing.Point(250, 31);
            this.dgvDetalleTemp.Name = "dgvDetalleTemp";
            this.dgvDetalleTemp.ReadOnly = true;
            this.dgvDetalleTemp.Size = new System.Drawing.Size(408, 150);
            this.dgvDetalleTemp.TabIndex = 30;
            this.dgvDetalleTemp.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleTemp_CellEndEdit);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(408, 221);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 31;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminarPlato
            // 
            this.btnEliminarPlato.Location = new System.Drawing.Point(165, 221);
            this.btnEliminarPlato.Name = "btnEliminarPlato";
            this.btnEliminarPlato.Size = new System.Drawing.Size(101, 23);
            this.btnEliminarPlato.TabIndex = 32;
            this.btnEliminarPlato.Text = "Eliminar Plato";
            this.btnEliminarPlato.UseVisualStyleBackColor = true;
            this.btnEliminarPlato.Click += new System.EventHandler(this.btnEliminarPlato_Click);
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.Location = new System.Drawing.Point(272, 221);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(120, 23);
            this.btnCancelarPedido.TabIndex = 33;
            this.btnCancelarPedido.Text = "Cancelar Pedido";
            this.btnCancelarPedido.UseVisualStyleBackColor = true;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(500, 221);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 34;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // EditarPedidoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelarPedido);
            this.Controls.Add(this.btnEliminarPlato);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvDetalleTemp);
            this.Controls.Add(this.btnAgregarPlato);
            this.Controls.Add(this.txtComentarioEdit);
            this.Controls.Add(this.txtCantidadEdit);
            this.Controls.Add(this.txtJustificacion);
            this.Controls.Add(this.cbPlato);
            this.Controls.Add(this.cbTipoConsumo);
            this.Controls.Add(this.cbMesa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditarPedidoForm";
            this.Text = "EditarPedidoForm";
            this.Load += new System.EventHandler(this.EditarPedidoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMesa;
        private System.Windows.Forms.ComboBox cbTipoConsumo;
        private System.Windows.Forms.ComboBox cbPlato;
        private System.Windows.Forms.TextBox txtJustificacion;
        private System.Windows.Forms.TextBox txtCantidadEdit;
        private System.Windows.Forms.TextBox txtComentarioEdit;
        private System.Windows.Forms.Button btnAgregarPlato;
        private System.Windows.Forms.DataGridView dgvDetalleTemp;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminarPlato;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.Button btnSalir;
    }
}