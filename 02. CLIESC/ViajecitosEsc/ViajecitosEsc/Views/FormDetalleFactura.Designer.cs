namespace ViajecitosEsc.Views
{
    partial class FormDetalleFactura
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
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnDescargarPdf = new Button();
            lblTotal = new Label();
            lblImpuesto = new Label();
            lblSubtotal = new Label();
            lblTarifa = new Label();
            lblCantidad = new Label();
            lblDescripcion = new Label();
            lblMetodoPago = new Label();
            lblTelefono = new Label();
            lblUsuario = new Label();
            lblEmpleado = new Label();
            lblFecha = new Label();
            lblNumero = new Label();
            dgvAmortizacion = new DataGridView();
            btnRegresar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).BeginInit();
            SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(401, 386);
            label13.Name = "label13";
            label13.Size = new Size(45, 20);
            label13.TabIndex = 56;
            label13.Text = "Total:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(401, 326);
            label12.Name = "label12";
            label12.Size = new Size(116, 20);
            label12.TabIndex = 55;
            label12.Text = "Impuesto (15%):";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(401, 266);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 54;
            label11.Text = "Subtotal:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(403, 211);
            label10.Name = "label10";
            label10.Size = new Size(48, 20);
            label10.TabIndex = 53;
            label10.Text = "Tarifa:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(401, 159);
            label9.Name = "label9";
            label9.Size = new Size(126, 20);
            label9.TabIndex = 52;
            label9.Text = "Cantidad boletos:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(404, 115);
            label8.Name = "label8";
            label8.Size = new Size(90, 20);
            label8.TabIndex = 51;
            label8.Text = "Descripción:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 376);
            label7.Name = "label7";
            label7.Size = new Size(143, 20);
            label7.TabIndex = 50;
            label7.Text = "Instrucción de pago:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(39, 311);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 49;
            label6.Text = "Teléfono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 252);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 48;
            label5.Text = "Usuario:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 200);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 47;
            label4.Text = "Empleado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 138);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 46;
            label3.Text = "Fecha:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 107);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 45;
            label2.Text = "Factura Nro:";
            // 
            // btnDescargarPdf
            // 
            btnDescargarPdf.Location = new Point(336, 758);
            btnDescargarPdf.Name = "btnDescargarPdf";
            btnDescargarPdf.Size = new Size(140, 29);
            btnDescargarPdf.TabIndex = 44;
            btnDescargarPdf.Text = "Descargar PDF";
            btnDescargarPdf.UseVisualStyleBackColor = true;
            btnDescargarPdf.Click += btnDescargarPdf_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(401, 406);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(0, 20);
            lblTotal.TabIndex = 43;
            // 
            // lblImpuesto
            // 
            lblImpuesto.AutoSize = true;
            lblImpuesto.Location = new Point(401, 355);
            lblImpuesto.Name = "lblImpuesto";
            lblImpuesto.Size = new Size(0, 20);
            lblImpuesto.TabIndex = 42;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(401, 296);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(0, 20);
            lblSubtotal.TabIndex = 41;
            // 
            // lblTarifa
            // 
            lblTarifa.AutoSize = true;
            lblTarifa.Location = new Point(401, 231);
            lblTarifa.Name = "lblTarifa";
            lblTarifa.Size = new Size(0, 20);
            lblTarifa.TabIndex = 40;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(403, 179);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(0, 20);
            lblCantidad.TabIndex = 39;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(401, 138);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(0, 20);
            lblDescripcion.TabIndex = 38;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(42, 406);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(0, 20);
            lblMetodoPago.TabIndex = 37;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(39, 339);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(0, 20);
            lblTelefono.TabIndex = 36;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(39, 277);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(0, 20);
            lblUsuario.TabIndex = 35;
            // 
            // lblEmpleado
            // 
            lblEmpleado.AutoSize = true;
            lblEmpleado.Location = new Point(40, 220);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new Size(0, 20);
            lblEmpleado.TabIndex = 34;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(44, 158);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(0, 20);
            lblFecha.TabIndex = 33;
            // 
            // lblNumero
            // 
            lblNumero.AutoSize = true;
            lblNumero.Location = new Point(134, 107);
            lblNumero.Name = "lblNumero";
            lblNumero.Size = new Size(0, 20);
            lblNumero.TabIndex = 32;
            // 
            // dgvAmortizacion
            // 
            dgvAmortizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAmortizacion.Location = new Point(39, 459);
            dgvAmortizacion.Name = "dgvAmortizacion";
            dgvAmortizacion.RowHeadersWidth = 51;
            dgvAmortizacion.Size = new Size(723, 283);
            dgvAmortizacion.TabIndex = 31;
            // 
            // btnRegresar
            // 
            btnRegresar.Location = new Point(326, 26);
            btnRegresar.Name = "btnRegresar";
            btnRegresar.Size = new Size(94, 29);
            btnRegresar.TabIndex = 57;
            btnRegresar.Text = "Regresar";
            btnRegresar.UseVisualStyleBackColor = true;
            btnRegresar.Click += btnRegresar_Click;
            // 
            // FormDetalleFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 895);
            Controls.Add(btnRegresar);
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
            Controls.Add(btnDescargarPdf);
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
            Controls.Add(dgvAmortizacion);
            Name = "FormDetalleFactura";
            Text = "FormDetalleFactura";
            ((System.ComponentModel.ISupportInitialize)dgvAmortizacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnDescargarPdf;
        private Label lblTotal;
        private Label lblImpuesto;
        private Label lblSubtotal;
        private Label lblTarifa;
        private Label lblCantidad;
        private Label lblDescripcion;
        private Label lblMetodoPago;
        private Label lblTelefono;
        private Label lblUsuario;
        private Label lblEmpleado;
        private Label lblFecha;
        private Label lblNumero;
        private DataGridView dgvAmortizacion;
        private Button btnRegresar;
    }
}