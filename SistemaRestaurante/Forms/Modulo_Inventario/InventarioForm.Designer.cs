namespace SistemaRestaurante.Forms.Modulo_Inventario
{
    partial class InventarioForm
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
            this.btnInsumos = new System.Windows.Forms.Button();
            this.btnMovimiento = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido a manejo de inventario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(253, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Que desea realizar?";
            // 
            // btnInsumos
            // 
            this.btnInsumos.Location = new System.Drawing.Point(375, 131);
            this.btnInsumos.Name = "btnInsumos";
            this.btnInsumos.Size = new System.Drawing.Size(75, 23);
            this.btnInsumos.TabIndex = 2;
            this.btnInsumos.Text = "Insumos";
            this.btnInsumos.UseVisualStyleBackColor = true;
            this.btnInsumos.Click += new System.EventHandler(this.btnInsumos_Click);
            // 
            // btnMovimiento
            // 
            this.btnMovimiento.Location = new System.Drawing.Point(375, 180);
            this.btnMovimiento.Name = "btnMovimiento";
            this.btnMovimiento.Size = new System.Drawing.Size(146, 23);
            this.btnMovimiento.TabIndex = 3;
            this.btnMovimiento.Text = "Movimiento inventario";
            this.btnMovimiento.UseVisualStyleBackColor = true;
            this.btnMovimiento.Click += new System.EventHandler(this.btnMovimiento_Click);
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(375, 222);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(75, 23);
            this.btnStock.TabIndex = 4;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Agregar/Editar insumos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Registrar compras o perdidas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Consultar el Stock";
            // 
            // InventarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnMovimiento);
            this.Controls.Add(this.btnInsumos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InventarioForm";
            this.Text = "InventarioForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInsumos;
        private System.Windows.Forms.Button btnMovimiento;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}