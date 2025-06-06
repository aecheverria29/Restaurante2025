﻿using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using SistemaRestaurante.Forms;
using SistemaRestaurante.Services;

namespace SistemaRestaurante
{
    public partial class LoginForm : Form
    {
        private Label lblBienvenida;

        public LoginForm()
        {
            InitializeComponent();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Fondo suave para todo el formulario
            this.BackColor = Color.FromArgb(248, 248, 252);

            // Título
            lblTitulo.Text = "Bienvenido a PlatyPlus";
            lblTitulo.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(72, 49, 240);
            lblTitulo.AutoSize = true;
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblTitulo.Top = 60;

            // Usuario
            lblUsuario.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblUsuario.Left = lblTitulo.Left - 30;
            lblUsuario.Top = lblTitulo.Bottom + 45;

            txtUsuario.Font = new Font("Segoe UI", 12);
            txtUsuario.Width = 260;
            txtUsuario.Left = lblTitulo.Left + 70;
            txtUsuario.Top = lblUsuario.Top - 4;
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;

            // Contraseña
            lblContrasena.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblContrasena.Left = lblUsuario.Left;
            lblContrasena.Top = txtUsuario.Bottom + 25;

            txtContrasena.Font = new Font("Segoe UI", 12);
            txtContrasena.Width = 260;
            txtContrasena.Left = txtUsuario.Left;
            txtContrasena.Top = lblContrasena.Top - 4;
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.PasswordChar = '●';

            // Botón Iniciar (Login)
            btnLogin.Text = "Iniciar";
            btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnLogin.Width = 120;
            btnLogin.Height = 38;
            btnLogin.Top = txtContrasena.Bottom + 35;
            btnLogin.Left = lblUsuario.Left;
            btnLogin.BackColor = Color.FromArgb(37, 150, 97);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.MouseEnter += (s, ev) => btnLogin.BackColor = Color.FromArgb(44, 180, 110);
            btnLogin.MouseLeave += (s, ev) => btnLogin.BackColor = Color.FromArgb(37, 150, 97);

            // Botón Salir
            btnSalir.Text = "Salir";
            btnSalir.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSalir.Width = 120;
            btnSalir.Height = 38;
            btnSalir.Top = btnLogin.Top;
            btnSalir.Left = txtUsuario.Left;
            btnSalir.BackColor = Color.FromArgb(207, 73, 73);
            btnSalir.ForeColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.MouseEnter += (s, ev) => btnSalir.BackColor = Color.FromArgb(230, 90, 90);
            btnSalir.MouseLeave += (s, ev) => btnSalir.BackColor = Color.FromArgb(207, 73, 73);

            // Centrando los botones horizontalmente respecto a los textboxes
            int espacioBotones = 28;
            btnLogin.Left = lblTitulo.Left + 10;
            btnSalir.Left = btnLogin.Right + espacioBotones;

            // Label bienvenida (creado programáticamente)
            if (lblBienvenida == null)
            {
                lblBienvenida = new Label();
                lblBienvenida.Visible = false;
                this.Controls.Add(lblBienvenida);
            }

            // Opción: Enter al textbox llama btnLogin
            txtContrasena.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                    btnLogin.PerformClick();
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE Usuario = @usuario AND Contrasena = @contrasena", conn);
                    cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@contrasena", txtContrasena.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        // --------- Bienvenida Mejorada y Centrada ---------
                        lblBienvenida.Text = $"¡Bienvenido, {txtUsuario.Text}!";
                        lblBienvenida.Font = new Font("Segoe UI", 24, FontStyle.Bold);
                        lblBienvenida.ForeColor = Color.FromArgb(36, 182, 95);
                        lblBienvenida.AutoSize = true;

                        // CENTRAR: justo debajo del botón Iniciar
                        lblBienvenida.Top = btnLogin.Bottom + 22;
                        lblBienvenida.Left = (this.ClientSize.Width - lblBienvenida.PreferredWidth) / 2;
                        lblBienvenida.BringToFront();
                        lblBienvenida.Visible = true;

                        // Animación fade-in
                        Timer timer = new Timer();
                        int alpha = 0;
                        lblBienvenida.ForeColor = Color.FromArgb(alpha, 36, 182, 95);
                        timer.Interval = 15;
                        timer.Tick += (s2, e2) =>
                        {
                            if (alpha < 255)
                            {
                                alpha += 15;
                                lblBienvenida.ForeColor = Color.FromArgb(Math.Min(alpha, 255), 36, 182, 95);
                            }
                            else
                            {
                                timer.Stop();
                                // Espera 900ms y abre el main
                                Timer t2 = new Timer();
                                t2.Interval = 900;
                                t2.Tick += (s3, e3) =>
                                {
                                    t2.Stop();
                                    this.Hide();
                                    MainForm main = new MainForm();
                                    main.FormClosed += (s, args) => this.Show();
                                    main.Show();
                                    lblBienvenida.Visible = false;
                                };
                                t2.Start();
                            }
                        };
                        timer.Start();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales Incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
