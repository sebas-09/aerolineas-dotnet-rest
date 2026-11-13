namespace ViajecitosEsc.Views
{
    partial class FormLogin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnLogin = new Button();
            txtCorreo = new TextBox();
            txtContrasena = new TextBox();
            label4 = new Label();
            lblError = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(331, 107);
            label1.Name = "label1";
            label1.Size = new Size(320, 31);
            label1.TabIndex = 0;
            label1.Text = "Bienvenidos a Viajecitos S.A.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(331, 231);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 1;
            label2.Text = "Correo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(326, 308);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 2;
            label3.Text = "Contraseña";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(451, 408);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(326, 267);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(301, 27);
            txtCorreo.TabIndex = 4;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(326, 348);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(301, 27);
            txtContrasena.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(425, 168);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 6;
            label4.Text = "Iniciar Sesión";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(470, 201);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 7;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(959, 512);
            Controls.Add(lblError);
            Controls.Add(label4);
            Controls.Add(txtContrasena);
            Controls.Add(txtCorreo);
            Controls.Add(btnLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnLogin;
        private TextBox txtCorreo;
        private TextBox txtContrasena;
        private Label label4;
        private Label lblError;
    }
}