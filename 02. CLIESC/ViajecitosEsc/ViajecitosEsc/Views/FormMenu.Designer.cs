namespace ViajecitosEsc.Views
{
    partial class FormMenu
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
            btnBuscarVuelos = new Button();
            btnCarrito = new Button();
            btnFacturas = new Button();
            btnHistorial = new Button();
            btnLogout = new Button();
            lblUsuario = new Label();
            SuspendLayout();
            // 
            // btnBuscarVuelos
            // 
            btnBuscarVuelos.BackColor = Color.MediumTurquoise;
            btnBuscarVuelos.Location = new Point(222, 147);
            btnBuscarVuelos.Name = "btnBuscarVuelos";
            btnBuscarVuelos.Size = new Size(156, 59);
            btnBuscarVuelos.TabIndex = 0;
            btnBuscarVuelos.Text = "Buscar Vuelos";
            btnBuscarVuelos.UseVisualStyleBackColor = false;
            btnBuscarVuelos.Click += btnBuscarVuelos_Click;
            // 
            // btnCarrito
            // 
            btnCarrito.Location = new Point(450, 147);
            btnCarrito.Name = "btnCarrito";
            btnCarrito.Size = new Size(159, 59);
            btnCarrito.TabIndex = 1;
            btnCarrito.Text = "Revisar Carrito";
            btnCarrito.UseVisualStyleBackColor = true;
            btnCarrito.Click += btnCarrito_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.BackColor = Color.LimeGreen;
            btnFacturas.Location = new Point(222, 258);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Size = new Size(156, 58);
            btnFacturas.TabIndex = 2;
            btnFacturas.Text = "Facturas";
            btnFacturas.UseVisualStyleBackColor = false;
            btnFacturas.Click += btnFacturas_Click;
            // 
            // btnHistorial
            // 
            btnHistorial.BackColor = Color.Gold;
            btnHistorial.Location = new Point(450, 258);
            btnHistorial.Name = "btnHistorial";
            btnHistorial.Size = new Size(159, 58);
            btnHistorial.TabIndex = 3;
            btnHistorial.Text = "Historial de Compras";
            btnHistorial.UseVisualStyleBackColor = false;
            btnHistorial.Click += btnHistorial_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.IndianRed;
            btnLogout.Location = new Point(340, 388);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(127, 29);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Cerrar Sesión";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(364, 61);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(50, 20);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "label1";
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.vuelo;
            ClientSize = new Size(800, 450);
            Controls.Add(lblUsuario);
            Controls.Add(btnLogout);
            Controls.Add(btnHistorial);
            Controls.Add(btnFacturas);
            Controls.Add(btnCarrito);
            Controls.Add(btnBuscarVuelos);
            Name = "FormMenu";
            Text = "FormMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscarVuelos;
        private Button btnCarrito;
        private Button btnFacturas;
        private Button btnHistorial;
        private Button btnLogout;
        private Label lblUsuario;
    }
}