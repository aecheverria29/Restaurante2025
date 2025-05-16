namespace SistemaRestaurante.Forms
{
    partial class MenuForm
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
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCategoriaPadre = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubcategoria = new System.Windows.Forms.TextBox();
            this.btnAgregarSubcategoria = new System.Windows.Forms.Button();
            this.dgvSubCategorias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoria";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(93, 31);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(100, 20);
            this.txtCategoria.TabIndex = 1;
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Location = new System.Drawing.Point(220, 27);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarCategoria.TabIndex = 2;
            this.btnAgregarCategoria.Text = "Agregar";
            this.btnAgregarCategoria.UseVisualStyleBackColor = true;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Location = new System.Drawing.Point(26, 133);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.ReadOnly = true;
            this.dgvCategorias.Size = new System.Drawing.Size(269, 150);
            this.dgvCategorias.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Categoria Padre";
            // 
            // cbCategoriaPadre
            // 
            this.cbCategoriaPadre.FormattingEnabled = true;
            this.cbCategoriaPadre.Location = new System.Drawing.Point(457, 37);
            this.cbCategoriaPadre.Name = "cbCategoriaPadre";
            this.cbCategoriaPadre.Size = new System.Drawing.Size(121, 21);
            this.cbCategoriaPadre.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subcategoria";
            // 
            // txtSubcategoria
            // 
            this.txtSubcategoria.Location = new System.Drawing.Point(457, 69);
            this.txtSubcategoria.Name = "txtSubcategoria";
            this.txtSubcategoria.Size = new System.Drawing.Size(100, 20);
            this.txtSubcategoria.TabIndex = 7;
            // 
            // btnAgregarSubcategoria
            // 
            this.btnAgregarSubcategoria.Location = new System.Drawing.Point(615, 34);
            this.btnAgregarSubcategoria.Name = "btnAgregarSubcategoria";
            this.btnAgregarSubcategoria.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarSubcategoria.TabIndex = 8;
            this.btnAgregarSubcategoria.Text = "Agregar";
            this.btnAgregarSubcategoria.UseVisualStyleBackColor = true;
            this.btnAgregarSubcategoria.Click += new System.EventHandler(this.btnAgregarSubcategoria_Click);
            // 
            // dgvSubCategorias
            // 
            this.dgvSubCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubCategorias.Location = new System.Drawing.Point(399, 121);
            this.dgvSubCategorias.Name = "dgvSubCategorias";
            this.dgvSubCategorias.ReadOnly = true;
            this.dgvSubCategorias.Size = new System.Drawing.Size(334, 150);
            this.dgvSubCategorias.TabIndex = 9;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvSubCategorias);
            this.Controls.Add(this.btnAgregarSubcategoria);
            this.Controls.Add(this.txtSubcategoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCategoriaPadre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCategorias);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.label1);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCategoriaPadre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubcategoria;
        private System.Windows.Forms.Button btnAgregarSubcategoria;
        private System.Windows.Forms.DataGridView dgvSubCategorias;
    }
}