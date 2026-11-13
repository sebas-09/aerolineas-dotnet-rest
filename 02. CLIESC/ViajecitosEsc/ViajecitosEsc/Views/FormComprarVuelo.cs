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
    public partial class FormComprarVuelo : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private readonly VueloViewModel _vuelo;

        public FormComprarVuelo(VueloViewModel vuelo)
        {
            InitializeComponent();
            _vuelo = vuelo;
            CargarDatosVuelo();
            cmbTipoTarjeta.Items.AddRange(new[] { "Crédito", "Débito" });
            if (cmbTipoTarjeta.Items.Count > 0)
                cmbTipoTarjeta.SelectedIndex = 0;
        }

        private void CargarDatosVuelo()
        {
            lblOrigen.Text = _vuelo.CiudadOrigen;
            lblDestino.Text = _vuelo.CiudadDestino;
            lblFecha.Text = _vuelo.HoraSalida.ToString("yyyy-MM-dd HH:mm");
            lblPrecio.Text = _vuelo.Valor.ToString("C");
            nudCantidad.Value = 1;
        }

        private async void btnComprar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreTitular.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoSeguridad.Text))
            {
                lblError.Text = "Complete todos los campos de pago.";
                return;
            }

            var compra = new CompraViewModel
            {
                IdVuelo = _vuelo.IdVuelo,
                IdUsuario = SesionApp.IdUsuario ?? 0,
                CantidadBoletos = (int)nudCantidad.Value,
                Pago = new PagoViewModel
                {
                    TipoTarjeta = cmbTipoTarjeta.SelectedItem?.ToString(),
                    NombreTitular = txtNombreTitular.Text,
                    NumeroTarjeta = txtNumeroTarjeta.Text,
                    CodigoSeguridad = txtCodigoSeguridad.Text,
                    // Si tienes campos de diferido, agrégalos aquí
                }
            };

            var factura = await _apiService.ComprarAsync(compra);

            if (factura == null)
            {
                lblError.Text = "Error al realizar la compra. Verifique los datos.";
                return;
            }

            MessageBox.Show("¡Compra exitosa! Factura N° " + factura.IdFactura, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
