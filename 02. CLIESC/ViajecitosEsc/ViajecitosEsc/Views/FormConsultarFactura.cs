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
    public partial class FormConsultarFactura : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private FacturaViewModel _facturaActual;

        public FormConsultarFactura()
        {
            InitializeComponent();
            dgvAmortizacion.Visible = false;
            lblError.Text = "";
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            dgvAmortizacion.Visible = false;

            if (!int.TryParse(txtIdFactura.Text, out int idFactura))
            {
                lblError.Text = "Ingrese un ID válido.";
                return;
            }

            var factura = await _apiService.GetFacturaAsync(idFactura);
            if (factura == null)
            {
                lblError.Text = $"No existe factura con el código {idFactura}.";
                LimpiarDatosFactura();
                return;
            }

            _facturaActual = factura;
            MostrarDatosFactura(factura);
        }

        private void MostrarDatosFactura(FacturaViewModel factura)
        {
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

        private void LimpiarDatosFactura()
        {
            lblNumero.Text = lblFecha.Text = lblEmpleado.Text = lblUsuario.Text = lblTelefono.Text =
            lblMetodoPago.Text = lblDescripcion.Text = lblCantidad.Text = lblTarifa.Text =
            lblSubtotal.Text = lblImpuesto.Text = lblTotal.Text = "";
            dgvAmortizacion.DataSource = null;
            dgvAmortizacion.Visible = false;
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

        private void lblTelefono_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            var formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void FormConsultarFactura_Load(object sender, EventArgs e)
        {

        }

        public async void CargarFacturaPorId(int idFactura)
        {
            lblError.Text = "";
            dgvAmortizacion.Visible = false;

            var factura = await _apiService.GetFacturaAsync(idFactura);
            if (factura == null)
            {
                lblError.Text = $"No existe factura con el código {idFactura}.";
                LimpiarDatosFactura();
                return;
            }

            _facturaActual = factura;
            MostrarDatosFactura(factura);
        }

        private void txtIdFactura_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
