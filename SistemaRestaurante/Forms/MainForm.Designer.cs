namespace SistemaRestaurante.Forms
{
    partial class MainForm
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
            this.panelContenido = new System.Windows.Forms.Panel();
            this.btnUsuarios = new MaterialSkin.Controls.MaterialButton();
            this.btnMenu = new MaterialSkin.Controls.MaterialButton();
            this.btnPlatos = new MaterialSkin.Controls.MaterialButton();
            this.btnPedidos = new MaterialSkin.Controls.MaterialButton();
            this.btnInventario = new MaterialSkin.Controls.MaterialButton();
            this.btnFacturacion = new MaterialSkin.Controls.MaterialButton();
            this.btnTurnos = new MaterialSkin.Controls.MaterialButton();
            this.btnCerrarSesion = new MaterialSkin.Controls.MaterialButton();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMesas = new MaterialSkin.Controls.MaterialButton();
            this.btnReportes = new MaterialSkin.Controls.MaterialButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenido
            // 
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(274, 52);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(533, 487);
            this.panelContenido.TabIndex = 1;
            this.panelContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenido_Paint);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUsuarios.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUsuarios.Depth = 0;
            this.btnUsuarios.HighEmphasis = true;
            this.btnUsuarios.Icon = null;
            this.btnUsuarios.Location = new System.Drawing.Point(38, 67);
            this.btnUsuarios.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnUsuarios.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUsuarios.Size = new System.Drawing.Size(91, 36);
            this.btnUsuarios.TabIndex = 10;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUsuarios.UseAccentColor = false;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click_1);
            // 
            // btnMenu
            // 
            this.btnMenu.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMenu.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMenu.Depth = 0;
            this.btnMenu.HighEmphasis = true;
            this.btnMenu.Icon = null;
            this.btnMenu.Location = new System.Drawing.Point(38, 106);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMenu.Size = new System.Drawing.Size(101, 36);
            this.btnMenu.TabIndex = 11;
            this.btnMenu.Text = "Categoria";
            this.btnMenu.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMenu.UseAccentColor = false;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu1_Click);
            // 
            // btnPlatos
            // 
            this.btnPlatos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPlatos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPlatos.Depth = 0;
            this.btnPlatos.HighEmphasis = true;
            this.btnPlatos.Icon = null;
            this.btnPlatos.Location = new System.Drawing.Point(41, 156);
            this.btnPlatos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPlatos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPlatos.Name = "btnPlatos";
            this.btnPlatos.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPlatos.Size = new System.Drawing.Size(76, 36);
            this.btnPlatos.TabIndex = 12;
            this.btnPlatos.Text = "Platos";
            this.btnPlatos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPlatos.UseAccentColor = false;
            this.btnPlatos.UseVisualStyleBackColor = true;
            this.btnPlatos.Click += new System.EventHandler(this.btnPlatos_Click_1);
            // 
            // btnPedidos
            // 
            this.btnPedidos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPedidos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPedidos.Depth = 0;
            this.btnPedidos.HighEmphasis = true;
            this.btnPedidos.Icon = null;
            this.btnPedidos.Location = new System.Drawing.Point(38, 195);
            this.btnPedidos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnPedidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPedidos.Name = "btnPedidos";
            this.btnPedidos.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnPedidos.Size = new System.Drawing.Size(82, 36);
            this.btnPedidos.TabIndex = 13;
            this.btnPedidos.Text = "Pedidos";
            this.btnPedidos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPedidos.UseAccentColor = false;
            this.btnPedidos.UseVisualStyleBackColor = true;
            this.btnPedidos.Click += new System.EventHandler(this.btnPedidos_Click_1);
            // 
            // btnInventario
            // 
            this.btnInventario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInventario.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnInventario.Depth = 0;
            this.btnInventario.HighEmphasis = true;
            this.btnInventario.Icon = null;
            this.btnInventario.Location = new System.Drawing.Point(38, 234);
            this.btnInventario.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnInventario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnInventario.Size = new System.Drawing.Size(107, 36);
            this.btnInventario.TabIndex = 14;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnInventario.UseAccentColor = false;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFacturacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFacturacion.Depth = 0;
            this.btnFacturacion.HighEmphasis = true;
            this.btnFacturacion.Icon = null;
            this.btnFacturacion.Location = new System.Drawing.Point(38, 273);
            this.btnFacturacion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnFacturacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFacturacion.Size = new System.Drawing.Size(121, 36);
            this.btnFacturacion.TabIndex = 15;
            this.btnFacturacion.Text = "Facturacion";
            this.btnFacturacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFacturacion.UseAccentColor = false;
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click_1);
            // 
            // btnTurnos
            // 
            this.btnTurnos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTurnos.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTurnos.Depth = 0;
            this.btnTurnos.HighEmphasis = true;
            this.btnTurnos.Icon = null;
            this.btnTurnos.Location = new System.Drawing.Point(38, 312);
            this.btnTurnos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnTurnos.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTurnos.Size = new System.Drawing.Size(78, 36);
            this.btnTurnos.TabIndex = 16;
            this.btnTurnos.Text = "Turnos";
            this.btnTurnos.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTurnos.UseAccentColor = false;
            this.btnTurnos.UseVisualStyleBackColor = true;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click_1);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCerrarSesion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCerrarSesion.Depth = 0;
            this.btnCerrarSesion.HighEmphasis = true;
            this.btnCerrarSesion.Icon = null;
            this.btnCerrarSesion.Location = new System.Drawing.Point(38, 429);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCerrarSesion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnCerrarSesion.Size = new System.Drawing.Size(122, 36);
            this.btnCerrarSesion.TabIndex = 17;
            this.btnCerrarSesion.Text = "Cerra Sesion ";
            this.btnCerrarSesion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCerrarSesion.UseAccentColor = false;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click_1);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelMenu.Controls.Add(this.pictureBox1);
            this.panelMenu.Controls.Add(this.btnMesas);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnTurnos);
            this.panelMenu.Controls.Add(this.btnFacturacion);
            this.panelMenu.Controls.Add(this.btnInventario);
            this.panelMenu.Controls.Add(this.btnPedidos);
            this.panelMenu.Controls.Add(this.btnPlatos);
            this.panelMenu.Controls.Add(this.btnMenu);
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(2, 52);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelMenu.Size = new System.Drawing.Size(272, 487);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnMesas
            // 
            this.btnMesas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnMesas.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnMesas.Depth = 0;
            this.btnMesas.HighEmphasis = true;
            this.btnMesas.Icon = null;
            this.btnMesas.Location = new System.Drawing.Point(38, 351);
            this.btnMesas.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnMesas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMesas.Name = "btnMesas";
            this.btnMesas.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnMesas.Size = new System.Drawing.Size(70, 36);
            this.btnMesas.TabIndex = 19;
            this.btnMesas.Text = "Mesas";
            this.btnMesas.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnMesas.UseAccentColor = false;
            this.btnMesas.UseVisualStyleBackColor = true;
            this.btnMesas.Click += new System.EventHandler(this.btnMesas_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReportes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReportes.Depth = 0;
            this.btnReportes.HighEmphasis = true;
            this.btnReportes.Icon = null;
            this.btnReportes.Location = new System.Drawing.Point(38, 390);
            this.btnReportes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnReportes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReportes.Size = new System.Drawing.Size(94, 36);
            this.btnReportes.TabIndex = 18;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReportes.UseAccentColor = false;
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(82, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 61);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 541);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(2, 52, 2, 2);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContenido;
        private MaterialSkin.Controls.MaterialButton btnUsuarios;
        private MaterialSkin.Controls.MaterialButton btnMenu;
        private MaterialSkin.Controls.MaterialButton btnPlatos;
        private MaterialSkin.Controls.MaterialButton btnPedidos;
        private MaterialSkin.Controls.MaterialButton btnInventario;
        private MaterialSkin.Controls.MaterialButton btnFacturacion;
        private MaterialSkin.Controls.MaterialButton btnTurnos;
        private MaterialSkin.Controls.MaterialButton btnCerrarSesion;
        private System.Windows.Forms.Panel panelMenu;
        private MaterialSkin.Controls.MaterialButton btnReportes;
        private MaterialSkin.Controls.MaterialButton btnMesas;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}