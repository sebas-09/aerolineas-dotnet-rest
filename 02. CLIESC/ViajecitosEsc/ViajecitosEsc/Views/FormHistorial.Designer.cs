namespace ViajecitosEsc.Views
{
    partial class FormHistorial
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
            lblError = new Label();
            dgvHistorial = new DataGridView();
            btnRegresarMenu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(38, 33);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 20);
            lblError.TabIndex = 0;
            lblError.Text = "label1";
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(23, 91);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.Size = new Size(746, 295);
            dgvHistorial.TabIndex = 1;
            dgvHistorial.CellDoubleClick += dgvHistorial_CellDoubleClick;
            // 
            // btnRegresarMenu
            // 
            btnRegresarMenu.Location = new Point(312, 409);
            btnRegresarMenu.Name = "btnRegresarMenu";
            btnRegresarMenu.Size = new Size(177, 29);
            btnRegresarMenu.TabIndex = 2;
            btnRegresarMenu.Text = "Regresar al Menú Principal";
            btnRegresarMenu.UseVisualStyleBackColor = true;
            btnRegresarMenu.Click += btnRegresarMenu_Click;
            // 
            // FormHistorial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegresarMenu);
            Controls.Add(dgvHistorial);
            Controls.Add(lblError);
            Name = "FormHistorial";
            Text = "FormHistorial";
            Load += FormHistorial_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblError;
        private DataGridView dgvHistorial;
        private Button btnRegresarMenu;
    }
}