using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViajecitosEsc.Models;
using ViajecitosEsc.Servicios;

namespace ViajecitosEsc.Views
{
    public partial class FormDetalleFactura : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private FacturaViewModel _facturaActual;

        public FormDetalleFactura(int idFactura)
        {
            InitializeComponent();
            CargarFactura(idFactura);
        }

        private async void CargarFactura(int idFactura)
        {
            var factura = await _apiService.GetFacturaAsync(idFactura);
            if (factura == null)
            {
                MessageBox.Show($"No existe factura con el código {idFactura}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _facturaActual = factura;

            // Aquí puedes reutilizar el método MostrarDatosFactura de FormConsultarFactura
            // O copiar la lógica para mostrar los datos en los labels y el DataGridView
            lblNumero.Text = factura.IdFactura.ToString();
            lblFecha.Text = factura.FechaFactura.ToString("yyyy-MM-dd HH:mm");
            lblEmpleado.Text = factura.Empleado;
            lblUsuario.Text = $"{factura.NombreUsuario} {factura.ApellidoUsuario}";
            lblTelefono.Text = factura.TelefonoUsuario;
            lblMetodoPago.Text = factura.MetodoPago;
            lblDescripcion.Text = factura.Descripcion;
            lblCantidad.Text = factura.CantidadBoletos.ToString();
            lblTarifa.Text = factura.TarifaUnitario.ToString("C");
            lblSubtotal.Text = factura.TotalParcial.ToString("C");
            lblImpuesto.Text = factura.Impuesto.ToString("C");
            lblTotal.Text = factura.TotalFinal.ToString("C");

            if (factura.TablaAmortizacion != null && factura.TablaAmortizacion.Count > 0)
            {
                dgvAmortizacion.DataSource = factura.TablaAmortizacion;
                dgvAmortizacion.Visible = true;
            }
            else
            {
                dgvAmortizacion.Visible = false;
            }
        }

        private void btnDescargarPdf_Click(object sender, EventArgs e)
        {
            if (_facturaActual == null)
                return;

            var pdfBytes = FacturaPdfService.GenerarPdf(_facturaActual);
            using (var sfd = new SaveFileDialog { Filter = "PDF files (*.pdf)|*.pdf", FileName = $"Factura_{_facturaActual.IdFactura}.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllBytes(sfd.FileName, pdfBytes);
                    MessageBox.Show("Factura guardada como PDF.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
