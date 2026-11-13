namespace ViajecitosEsc.Views
{
    partial class FormConsultarFactura
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
            dgvAmortizacion = new DataGridView();
            lblError = new Label();
            lblNumero = new Label();
            lblFecha = new Label();
            lblEmpleado = new Label();
            lblUsuario = new Label();
            lblTelefono = new Label();
            lblMetodoPago = new Label();
            lblDescripcion = new Label();
            lblCantidad = new Label();
            lblTarifa = new Label();
            lblSubtotal = new Label();
            lblImpuesto = new Label();
            lblTotal = new Label();
            btnBuscar = new Button();
            btnDescargarPdf = new Button();
            txtIdFactura = new TextBox();
            label1 = new Label();
            btnRegresarMenu = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).BeginInit();
            SuspendLayout();
            // 
            // dgvAmortizacion
            // 
            dgvAmortizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAmortizacion.Location = new Point(39, 462);
            dgvAmortizacion.Name = "dgvAmortizacion";
            dgvAmortizacion.RowHeadersWidth = 51;
            dgvAmortizacion.Size = new Size(723, 283);
            dgvAmortizacion.TabIndex = 0;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(40, 84);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 1;
            lblError.Click += lblError_Click;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(134, 110);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(0, 20);
            lblNumero.TabIndex = 2;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(44, 161);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 20);
            lblFecha.TabIndex = 3;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Location = new Point(40, 223);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(0, 20);
            lblEmpleado.TabIndex = 4;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(39, 280);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 20);
            lblUsuario.TabIndex = 5;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(39, 342);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(0, 20);
            lblTelefono.TabIndex = 6;
            lblTelefono.Click += lblTelefono_Click;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(42, 409);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(0, 20);
            lblMetodoPago.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(401, 141);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(0, 20);
            lblDescripcion.TabIndex = 8;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(403, 182);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(0, 20);
            lblCantidad.TabIndex = 9;
            // 
            // lblTarifa
            // 
            lblTarifa.AutoSize = true;
            lblTarifa.Location = new Point(401, 234);
            lblTarifa.Name = "lblTarifa";
            lblTarifa.Size = new Size(0, 20);
            lblTarifa.TabIndex = 10;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(401, 299);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(0, 20);
            lblSubtotal.TabIndex = 11;
            // 
            // lblImpuesto
            // 
            lblImpuesto.AutoSize = true;
            lblImpuesto.Location = new Point(401, 358);
            lblImpuesto.Name = "lblImpuesto";
            lblImpuesto.Size = new Size(0, 20);
            lblImpuesto.TabIndex = 12;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(401, 409);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 13;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(260, 53);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnDescargarPdf
            // 
            btnDescargarPdf.Location = new Point(336, 761);
            btnDescargarPdf.Name = "btnDescargarPdf";
            btnDescargarPdf.Size = new Size(140, 29);
            btnDescargarPdf.TabIndex = 15;
            btnDescargarPdf.Text = "Descargar PDF";
            btnDescargarPdf.UseVisualStyleBackColor = true;
            btnDescargarPdf.Click += btnDescargarPdf_Click;
            // 
            // txtIdFactura
            // 
            txtIdFactura.Location = new Point(40, 54);
            txtIdFactura.Name = "txtIdFactura";
            txtIdFactura.Size = new Size(180, 27);
            txtIdFactura.TabIndex = 16;
            txtIdFactura.TextChanged += txtIdFactura_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 24);
            label1.Name = "label1";
            label1.Size = new Size(182, 20);
            label1.TabIndex = 17;
            label1.Text = "Ingrese el ID de la factura:";
            // 
            // btnRegresarMenu
            // 
            btnRegresarMenu.Location = new Point(544, 52);
            btnRegresarMenu.Name = "btnRegresarMenu";
            btnRegresarMenu.Size = new Size(223, 29);
            btnRegresarMenu.TabIndex = 18;
            btnRegresarMenu.Text = "Regresar al Menú Principal";
            btnRegresarMenu.UseVisualStyleBackColor = true;
            btnRegresarMenu.Click += btnRegresarMenu_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 110);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 19;
            label2.Text = "Factura Nro:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 141);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 20;
            label3.Text = "Fecha:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 203);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 21;
            label4.Text = "Empleado:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 255);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 22;
            label5.Text = "Usuario:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 314);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 23;
            label6.Text = "Teléfono:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 379);
            label7.Name = "label7";
            label7.Size = new Size(143, 20);
            label7.TabIndex = 24;
            label7.Text = "Instrucción de pago:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(404, 118);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 25;
            label8.Text = "Descripción:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(401, 162);
            label9.Name = "label9";
            label9.Size = new Size(126, 20);
            label9.TabIndex = 26;
            label9.Text = "Cantidad boletos:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(403, 214);
            label10.Name = "label10";
            label10.Size = new Size(48, 20);
            label10.TabIndex = 27;
            label10.Text = "Tarifa:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(401, 269);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 28;
            label11.Text = "Subtotal:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(401, 329);
            label12.Name = "label12";
            label12.Size = new Size(116, 20);
            label12.TabIndex = 29;
            label12.Text = "Impuesto (15%):";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(401, 389);
            label13.Name = "label13";
            label13.Size = new Size(45, 20);
            label13.TabIndex = 30;
            label13.Text = "Total:";
            // 
            // FormConsultarFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 802);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnRegresarMenu);
            Controls.Add(label1);
            Controls.Add(txtIdFactura);
            Controls.Add(btnDescargarPdf);
            Controls.Add(btnBuscar);
            Controls.Add(lblTotal);
            Controls.Add(lblImpuesto);
            Controls.Add(lblSubtotal);
            Controls.Add(lblTarifa);
            Controls.Add(lblCantidad);
            Controls.Add(lblDescripcion);
            Controls.Add(lblMetodoPago);
            Controls.Add(lblTelefono);
            Controls.Add(lblUsuario);
            Controls.Add(lblEmpleado);
            Controls.Add(lblFecha);
            Controls.Add(lblNumero);
            Controls.Add(lblError);
            Controls.Add(dgvAmortizacion);
            Name = "FormConsultarFactura";
            Text = "FormConsultarFactura";
            Load += FormConsultarFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAmortizacion;
        private Label lblError;
        private Label lblNumero;
        private Label lblFecha;
        private Label lblEmpleado;
        private Label lblUsuario;
        private Label lblTelefono;
        private Label lblMetodoPago;
        private Label lblDescripcion;
        private Label lblCantidad;
        private Label lblTarifa;
        private Label lblSubtotal;
        private Label lblImpuesto;
        private Label lblTotal;
        private Button btnBuscar;
        private Button btnDescargarPdf;
        private TextBox txtIdFactura;
        private Label label1;
        private Button btnRegresarMenu;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
    }
}