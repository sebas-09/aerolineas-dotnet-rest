namespace ViajecitosEsc.Views
{
    partial class FormPagoCarrito
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
            lblTotal = new Label();
            cmbTipoTarjeta = new ComboBox();
            cmbDiferido = new ComboBox();
            cmbTipoAmortizacion = new ComboBox();
            nudMesesDiferido = new NumericUpDown();
            dgvAmortizacion = new DataGridView();
            lblError = new Label();
            btnConfirmar = new Button();
            txtNombreTitular = new TextBox();
            txtNumeroTarjeta = new TextBox();
            txtCodigoSeguridad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudMesesDiferido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).BeginInit();
            SuspendLayout();
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(62, 53);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "label1";
            // 
            // cmbTipoTarjeta
            // 
            cmbTipoTarjeta.FormattingEnabled = true;
            cmbTipoTarjeta.Location = new Point(63, 111);
            cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            cmbTipoTarjeta.Size = new Size(200, 28);
            cmbTipoTarjeta.TabIndex = 1;
            cmbTipoTarjeta.SelectedIndexChanged += cmbTipoTarjeta_SelectedIndexChanged;
            // 
            // cmbDiferido
            // 
            cmbDiferido.FormattingEnabled = true;
            cmbDiferido.Location = new Point(63, 168);
            cmbDiferido.Name = "cmbDiferido";
            cmbDiferido.Size = new Size(200, 28);
            cmbDiferido.TabIndex = 2;
            cmbDiferido.SelectedIndexChanged += cmbDiferido_SelectedIndexChanged;
            // 
            // cmbTipoAmortizacion
            // 
            cmbTipoAmortizacion.FormattingEnabled = true;
            cmbTipoAmortizacion.Location = new Point(62, 227);
            cmbTipoAmortizacion.Name = "cmbTipoAmortizacion";
            cmbTipoAmortizacion.Size = new Size(201, 28);
            cmbTipoAmortizacion.TabIndex = 3;
            cmbTipoAmortizacion.SelectedIndexChanged += cmbTipoAmortizacion_SelectedIndexChanged;
            // 
            // nudMesesDiferido
            // 
            nudMesesDiferido.Location = new Point(62, 289);
            nudMesesDiferido.Name = "nudMesesDiferido";
            nudMesesDiferido.Size = new Size(150, 27);
            nudMesesDiferido.TabIndex = 4;
            nudMesesDiferido.ValueChanged += nudMesesDiferido_ValueChanged;
            // 
            // dgvAmortizacion
            // 
            dgvAmortizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAmortizacion.Location = new Point(39, 444);
            dgvAmortizacion.Name = "dgvAmortizacion";
            dgvAmortizacion.RowHeadersWidth = 51;
            dgvAmortizacion.Size = new Size(724, 275);
            dgvAmortizacion.TabIndex = 5;
            dgvAmortizacion.CellContentClick += dgvAmortizacion_CellContentClick;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(423, 374);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 20);
            lblError.TabIndex = 6;
            lblError.Text = "label1";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(562, 768);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(201, 29);
            btnConfirmar.TabIndex = 7;
            btnConfirmar.Text = "Continuar con el Pago";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // txtNombreTitular
            // 
            txtNombreTitular.Location = new Point(416, 112);
            txtNombreTitular.Name = "txtNombreTitular";
            txtNombreTitular.Size = new Size(225, 27);
            txtNombreTitular.TabIndex = 8;
            // 
            // txtNumeroTarjeta
            // 
            txtNumeroTarjeta.Location = new Point(416, 169);
            txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            txtNumeroTarjeta.Size = new Size(225, 27);
            txtNumeroTarjeta.TabIndex = 9;
            // 
            // txtCodigoSeguridad
            // 
            txtCodigoSeguridad.Location = new Point(416, 228);
            txtCodigoSeguridad.Name = "txtCodigoSeguridad";
            txtCodigoSeguridad.Size = new Size(91, 27);
            txtCodigoSeguridad.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 85);
            label1.Name = "label1";
            label1.Size = new Size(198, 20);
            label1.TabIndex = 11;
            label1.Text = "Seleccione el tipo de tarjeta:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 145);
            label2.Name = "label2";
            label2.Size = new Size(174, 20);
            label2.TabIndex = 12;
            label2.Text = "Desea Diferir su Compra:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 203);
            label3.Name = "label3";
            label3.Size = new Size(244, 20);
            label3.TabIndex = 13;
            label3.Text = "Seleccione el tipo de Amortización:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 264);
            label4.Name = "label4";
            label4.Size = new Size(304, 20);
            label4.TabIndex = 14;
            label4.Text = "Seleccione los meses a los que desea Diferir:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(416, 84);
            label5.Name = "label5";
            label5.Size = new Size(220, 20);
            label5.TabIndex = 15;
            label5.Text = "Nombre del Titular de la Tarjeta";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(416, 146);
            label6.Name = "label6";
            label6.Size = new Size(147, 20);
            label6.TabIndex = 16;
            label6.Text = "Número de la tarjeta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(418, 206);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 17;
            label7.Text = "Código CVV";
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(53, 774);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(159, 29);
            btnRegresar.TabIndex = 18;
            btnRegresar.Text = "Revisar el Carrito";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FormPagoCarrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 843);
            Controls.Add(btnRegresar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCodigoSeguridad);
            Controls.Add(txtNumeroTarjeta);
            Controls.Add(txtNombreTitular);
            Controls.Add(btnConfirmar);
            Controls.Add(lblError);
            Controls.Add(dgvAmortizacion);
            Controls.Add(nudMesesDiferido);
            Controls.Add(cmbTipoAmortizacion);
            Controls.Add(cmbDiferido);
            Controls.Add(cmbTipoTarjeta);
            Controls.Add(lblTotal);
            Name = "FormPagoCarrito";
            Text = "FormPagoCarrito";
            ((System.ComponentModel.ISupportInitialize)nudMesesDiferido).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotal;
        private ComboBox cmbTipoTarjeta;
        private ComboBox cmbDiferido;
        private ComboBox cmbTipoAmortizacion;
        private NumericUpDown nudMesesDiferido;
        private DataGridView dgvAmortizacion;
        private Label lblError;
        private Button btnConfirmar;
        private TextBox txtNombreTitular;
        private TextBox txtNumeroTarjeta;
        private TextBox txtCodigoSeguridad;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnRegresar;
    }
}