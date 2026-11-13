namespace ViajecitosEsc.Views
{
    partial class FormBuscarVuelos
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
            cmbOrigen = new ComboBox();
            cmbDestino = new ComboBox();
            dtpFecha = new DateTimePicker();
            btnBuscar = new Button();
            dgvVuelos = new DataGridView();
            btnComprar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).BeginInit();
            SuspendLayout();
            // 
            // cmbOrigen
            // 
            cmbOrigen.FormattingEnabled = true;
            cmbOrigen.Location = new Point(12, 55);
            cmbOrigen.Name = "cmbOrigen";
            cmbOrigen.Size = new Size(151, 28);
            cmbOrigen.TabIndex = 0;
            cmbOrigen.SelectedIndexChanged += cmbOrigen_SelectedIndexChanged;
            // 
            // cmbDestino
            // 
            cmbDestino.FormattingEnabled = true;
            cmbDestino.Location = new Point(184, 55);
            cmbDestino.Name = "cmbDestino";
            cmbDestino.Size = new Size(151, 28);
            cmbDestino.TabIndex = 1;
            cmbDestino.SelectedIndexChanged += cmbDestino_SelectedIndexChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(357, 56);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(250, 27);
            dtpFecha.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(643, 55);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvVuelos
            // 
            dgvVuelos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVuelos.Location = new Point(12, 109);
            dgvVuelos.Name = "dgvVuelos";
            dgvVuelos.RowHeadersWidth = 51;
            dgvVuelos.Size = new Size(725, 254);
            dgvVuelos.TabIndex = 4;
            // 
            // btnComprar
            // 
            btnComprar.Location = new Point(507, 388);
            btnComprar.Name = "btnComprar";
            btnComprar.Size = new Size(220, 29);
            btnComprar.TabIndex = 5;
            btnComprar.Text = "Agregar a Carrito de Compra";
            btnComprar.UseVisualStyleBackColor = true;
            btnComprar.Click += btnComprar_Click;
            // 
            // FormBuscarVuelos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnComprar);
            Controls.Add(dgvVuelos);
            Controls.Add(btnBuscar);
            Controls.Add(dtpFecha);
            Controls.Add(cmbDestino);
            Controls.Add(cmbOrigen);
            Name = "FormBuscarVuelos";
            Text = "FormBuscarVuelos";
            Load += FormBuscarVuelos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVuelos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbOrigen;
        private ComboBox cmbDestino;
        private DateTimePicker dtpFecha;
        private Button btnBuscar;
        private DataGridView dgvVuelos;
        private Button btnComprar;
    }
}