namespace SistemaRestaurante.Forms
{
    partial class FacturacionForm
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
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.v = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(16, 63);
            this.dgvPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.Size = new System.Drawing.Size(792, 247);
            this.dgvPedidos.TabIndex = 0;
            this.dgvPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellContentClick);
            // 
            // v
            // 
            this.v.AutoSize = true;
            this.v.Location = new System.Drawing.Point(37, 31);
            this.v.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.v.Name = "v";
            this.v.Size = new System.Drawing.Size(263, 16);
            this.v.TabIndex = 1;
            this.v.Text = "Lista de pedidos entregados no facturados";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(832, 74);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(100, 28);
            this.btnCobrar.TabIndex = 2;
            this.btnCobrar.Text = "Cobrar";
            this.btnCobrar.UseVisualStyleBackColor = true;
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(16, 368);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.ReadOnly = true;
            this.dgvDetallePedido.RowHeadersWidth = 51;
            this.dgvDetallePedido.RowTemplate.Height = 24;
            this.dgvDetallePedido.Size = new System.Drawing.Size(792, 150);
            this.dgvDetallePedido.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "DETALLE DE LOS PEDIDOS";
            // 
            // FacturacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDetallePedido);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.v);
            this.Controls.Add(this.dgvPedidos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FacturacionForm";
            this.Text = "FacturacionForm";
            this.Load += new System.EventHandler(this.FacturacionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label v;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.Label label1;
    }
}