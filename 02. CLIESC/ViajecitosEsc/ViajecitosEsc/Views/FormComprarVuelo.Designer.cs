namespace ViajecitosEsc.Views
{
    partial class FormComprarVuelo
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
            cmbTipoTarjeta = new ComboBox();
            lblOrigen = new Label();
            lblDestino = new Label();
            lblFecha = new Label();
            lblPrecio = new Label();
            nudCantidad = new NumericUpDown();
            lblError = new Label();
            btnComprar = new Button();
            txtNombreTitular = new TextBox();
            txtNumeroTarjeta = new TextBox();
            txtCodigoSeguridad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            SuspendLayout();
            // 
            // cmbTipoTarjeta
            // 
            cmbTipoTarjeta.FormattingEnabled = true;
            cmbTipoTarjeta.Location = new Point(45, 50);
            cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            cmbTipoTarjeta.Size = new Size(151, 28);
            cmbTipoTarjeta.TabIndex = 0;
            // 
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Location = new Point(63, 113);
            lblOrigen.Name = "lblOrigen";
            lblOrigen.Size = new Size(50, 20);
            lblOrigen.TabIndex = 1;
            lblOrigen.Text = "label1";
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Location = new Point(161, 119);
            lblDestino.Name = "lblDestino";
            lblDestino.Size = new Size(50, 20);
            lblDestino.TabIndex = 2;
            lblDestino.Text = "label2";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(258, 120);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(50, 20);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "label3";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(356, 119);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 4;
            lblPrecio.Text = "label4";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(460, 119);
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(150, 27);
            nudCantidad.TabIndex = 5;
            nudCantidad.ValueChanged += nudCantidad_ValueChanged;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(60, 171);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 20);
            lblError.TabIndex = 6;
            lblError.Text = "label1";
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(625, 390);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(94, 29);
            btnComprar.TabIndex = 7;
            btnComprar.Text = "button1";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // txtNombreTitular
            // 
            txtNombreTitular.Location = new Point(91, 285);
            txtNombreTitular.Name = "txtNombreTitular";
            txtNombreTitular.Size = new Size(125, 27);
            txtNombreTitular.TabIndex = 8;
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Location = new Point(308, 299);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.Size = new Size(125, 27);
            txtNumeroTarjeta.TabIndex = 9;
            // 
            // txtCodigoSeguridad
            // 
            txtCodigoSeguridad.Location = new Point(148, 366);
            txtCodigoSeguridad.Name = "txtCodigoSeguridad";
            txtCodigoSeguridad.Size = new Size(125, 27);
            txtCodigoSeguridad.TabIndex = 10;
            // 
            // FormComprarVuelo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtCodigoSeguridad);
            Controls.Add(txtNumeroTarjeta);
            Controls.Add(txtNombreTitular);
            Controls.Add(btnComprar);
            Controls.Add(lblError);
            Controls.Add(nudCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblFecha);
            Controls.Add(lblDestino);
            Controls.Add(lblOrigen);
            Controls.Add(cmbTipoTarjeta);
            Name = "FormComprarVuelo";
            Text = "FormComprarVuelo";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbTipoTarjeta;
        private Label lblOrigen;
        private Label lblDestino;
        private Label lblFecha;
        private Label lblPrecio;
        private NumericUpDown nudCantidad;
        private Label lblError;
        private Button btnComprar;
        private TextBox txtNombreTitular;
        private TextBox txtNumeroTarjeta;
        private TextBox txtCodigoSeguridad;
    }
}