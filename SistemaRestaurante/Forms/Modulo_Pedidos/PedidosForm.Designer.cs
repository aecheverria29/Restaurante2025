namespace SistemaRestaurante.Forms
{
    partial class PedidosForm
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
            this.cbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.dgvDetallePedido = new System.Windows.Forms.DataGridView();
            this.btnCambiarEstado = new System.Windows.Forms.Button();
            this.btnPedidoNuevo = new System.Windows.Forms.Button();
            this.btnEditarPedido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEstadoFiltro
            // 
            this.cbEstadoFiltro.FormattingEnabled = true;
            this.cbEstadoFiltro.Location = new System.Drawing.Point(36, 15);
            this.cbEstadoFiltro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbEstadoFiltro.Name = "cbEstadoFiltro";
            this.cbEstadoFiltro.Size = new System.Drawing.Size(160, 24);
            this.cbEstadoFiltro.TabIndex = 0;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(205, 15);
            this.btnFiltrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(100, 28);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(36, 98);
            this.dgvPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.ReadOnly = true;
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.Size = new System.Drawing.Size(716, 185);
            this.dgvPedidos.TabIndex = 2;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            // 
            // dgvDetallePedido
            // 
            this.dgvDetallePedido.AllowUserToAddRows = false;
            this.dgvDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallePedido.Location = new System.Drawing.Point(36, 290);
            this.dgvDetallePedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDetallePedido.Name = "dgvDetallePedido";
            this.dgvDetallePedido.ReadOnly = true;
            this.dgvDetallePedido.RowHeadersWidth = 51;
            this.dgvDetallePedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallePedido.Size = new System.Drawing.Size(931, 185);
            this.dgvDetallePedido.TabIndex = 3;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.Location = new System.Drawing.Point(746, 30);
            this.btnCambiarEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(124, 28);
            this.btnCambiarEstado.TabIndex = 4;
            this.btnCambiarEstado.Text = "Cambiar Estado";
            this.btnCambiarEstado.UseVisualStyleBackColor = true;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // btnPedidoNuevo
            // 
            this.btnPedidoNuevo.Location = new System.Drawing.Point(388, 30);
            this.btnPedidoNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPedidoNuevo.Name = "btnPedidoNuevo";
            this.btnPedidoNuevo.Size = new System.Drawing.Size(156, 28);
            this.btnPedidoNuevo.TabIndex = 5;
            this.btnPedidoNuevo.Text = "Pedido Nuevo";
            this.btnPedidoNuevo.UseVisualStyleBackColor = true;
            this.btnPedidoNuevo.Click += new System.EventHandler(this.btnPedidoNuevo_Click);
            // 
            // btnEditarPedido
            // 
            this.btnEditarPedido.Location = new System.Drawing.Point(573, 28);
            this.btnEditarPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarPedido.Name = "btnEditarPedido";
            this.btnEditarPedido.Size = new System.Drawing.Size(136, 28);
            this.btnEditarPedido.TabIndex = 6;
            this.btnEditarPedido.Text = "Editar Pedido";
            this.btnEditarPedido.UseVisualStyleBackColor = true;
            this.btnEditarPedido.Click += new System.EventHandler(this.btnEditarPedido_Click);
            // 
            // PedidosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnEditarPedido);
            this.Controls.Add(this.btnPedidoNuevo);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.dgvDetallePedido);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.cbEstadoFiltro);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PedidosForm";
            this.Text = "PedidosForm";
            this.Load += new System.EventHandler(this.PedidosForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallePedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEstadoFiltro;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvDetallePedido;
        private System.Windows.Forms.Button btnCambiarEstado;
        private System.Windows.Forms.Button btnPedidoNuevo;
        private System.Windows.Forms.Button btnEditarPedido;
    }
}