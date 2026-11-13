namespace ViajecitosEsc.Views
{
    partial class FormCarrito
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
            dgvCarrito = new DataGridView();
            lblTotal = new Label();
            lblError = new Label();
            btnAgregarVuelo = new Button();
            btnPagar = new Button();
            btnQuitar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // dgvCarrito
            // 
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(61, 52);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.Size = new Size(513, 188);
            dgvCarrito.TabIndex = 0;
            dgvCarrito.CellContentClick += dgvCarrito_CellContentClick;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(61, 286);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(50, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "label1";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(281, 296);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 2;
            // 
            // btnAgregarVuelo
            // 
            btnAgregarVuelo.Location = new Point(61, 365);
            btnAgregarVuelo.Name = "btnAgregarVuelo";
            btnAgregarVuelo.Size = new Size(151, 29);
            btnAgregarVuelo.TabIndex = 3;
            btnAgregarVuelo.Text = "Agregar Vuelos";
            btnAgregarVuelo.UseVisualStyleBackColor = true;
            btnAgregarVuelo.Click += btnAgregarVuelo_Click;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(568, 365);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(181, 29);
            btnPagar.TabIndex = 4;
            btnPagar.Text = "Proceder con el Pago";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(608, 124);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(141, 29);
            btnQuitar.TabIndex = 5;
            btnQuitar.Text = "Eliminar Vuelo";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // FormCarrito
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnQuitar);
            Controls.Add(btnPagar);
            Controls.Add(btnAgregarVuelo);
            Controls.Add(lblError);
            Controls.Add(lblTotal);
            Controls.Add(dgvCarrito);
            Name = "FormCarrito";
            Text = "FormCarrito";
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCarrito;
        private Label lblTotal;
        private Label lblError;
        private Button btnAgregarVuelo;
        private Button btnPagar;
        private Button btnQuitar;
    }
}