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

    public partial class FormPagoCarrito : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private readonly CarritoCompraViewModel _carrito;

        public FormPagoCarrito(CarritoCompraViewModel carrito)
        {
            InitializeComponent();
            _carrito = carrito;
            InicializarControles();
        }

        private void InicializarControles()
        {
            lblTotal.Text = $"Total: {_carrito.TotalCarrito:C}";

            cmbTipoTarjeta.Items.Clear();
            cmbTipoTarjeta.Items.AddRange(new[] { "Crédito", "Débito" });
            if (cmbTipoTarjeta.Items.Count > 0)
                cmbTipoTarjeta.SelectedIndex = 0;

            cmbDiferido.Items.Clear();
            cmbDiferido.Items.AddRange(new[] { "Sí", "No" });
            if (cmbDiferido.Items.Count > 0)
                cmbDiferido.SelectedIndex = 0;

            cmbTipoAmortizacion.Items.Clear();
            cmbTipoAmortizacion.Items.AddRange(new[] { "Alemana", "Francesa" });
            if (cmbTipoAmortizacion.Items.Count > 0)
                cmbTipoAmortizacion.SelectedIndex = 0;

            nudMesesDiferido.Minimum = 1;
            nudMesesDiferido.Maximum = 24;
            nudMesesDiferido.Value = 1;
            MostrarSeccionDiferido(false);
            dgvAmortizacion.Visible = false;
            lblError.Text = "";
        }

        private void cmbTipoTarjeta_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esCredito = cmbTipoTarjeta.SelectedItem?.ToString() == "Crédito";
            MostrarSeccionDiferido(esCredito);
            dgvAmortizacion.Visible = false;
        }

        private void cmbDiferido_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool diferido = cmbDiferido.SelectedItem?.ToString() == "Sí";
            nudMesesDiferido.Enabled = diferido;
            cmbTipoAmortizacion.Enabled = diferido;
            dgvAmortizacion.Visible = false;
            if (diferido)
                CalcularYMostrarAmortizacion();
        }

        private void nudMesesDiferido_ValueChanged(object sender, EventArgs e)
        {
            CalcularYMostrarAmortizacion();
        }

        private void cmbTipoAmortizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularYMostrarAmortizacion();
        }

        private async void CalcularYMostrarAmortizacion()
        {
            if (cmbTipoTarjeta.SelectedItem?.ToString() == "Crédito" &&
                cmbDiferido.SelectedItem?.ToString() == "Sí" &&
                nudMesesDiferido.Value > 0 &&
                !string.IsNullOrEmpty(cmbTipoAmortizacion.Text))
            {
                var tabla = await _apiService.CalcularAmortizacionAsync(
                    _carrito.TotalCarrito,
                    (int)nudMesesDiferido.Value,
                    cmbTipoAmortizacion.Text.ToLower()
                );
                dgvAmortizacion.DataSource = tabla;
                dgvAmortizacion.Visible = true;
            }
            else
            {
                dgvAmortizacion.Visible = false;
            }
        }

        private void MostrarSeccionDiferido(bool mostrar)
        {
            cmbDiferido.Enabled = mostrar;
            if (mostrar && cmbDiferido.Items.Count > 0)
                cmbDiferido.SelectedIndex = 0;
            else
                cmbDiferido.SelectedIndex = -1;

            nudMesesDiferido.Enabled = false;
            cmbTipoAmortizacion.Enabled = false;
            nudMesesDiferido.Value = 1;
            cmbTipoAmortizacion.SelectedIndex = -1;
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtNombreTitular.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroTarjeta.Text) ||
                string.IsNullOrWhiteSpace(txtCodigoSeguridad.Text))
            {
                lblError.Text = "Complete todos los campos de pago.";
                return;
            }

            var pago = new PagoViewModel
            {
                TipoTarjeta = cmbTipoTarjeta.SelectedItem?.ToString(),
                NombreTitular = txtNombreTitular.Text,
                NumeroTarjeta = txtNumeroTarjeta.Text,
                CodigoSeguridad = txtCodigoSeguridad.Text,
                Diferido = (cmbTipoTarjeta.SelectedItem?.ToString() == "Crédito" && cmbDiferido.SelectedItem?.ToString() == "Sí"),
                MesesDiferido = (cmbTipoTarjeta.SelectedItem?.ToString() == "Crédito" && cmbDiferido.SelectedItem?.ToString() == "Sí") ? (int?)nudMesesDiferido.Value : null
            };

            _carrito.Pago = pago;
            _carrito.TipoAmortizacion = (pago.Diferido == true) ? cmbTipoAmortizacion.Text.ToLower() : null;

            var resultado = await _apiService.ComprarConResultadoAsync(_carrito);

            if (!string.IsNullOrWhiteSpace(resultado.Error))
            {
                lblError.Text = resultado.Error;
                return;
            }

            if (resultado.Factura == null)
            {
                lblError.Text = "No se pudo realizar la compra. Inténtalo nuevamente.";
                return;
            }

            MessageBox.Show("¡Compra exitosa! Factura N° " + resultado.Factura.IdFactura, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CarritoSesion.Carrito = null;
            var formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }

        private void dgvAmortizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            // Vuelve al carrito
            var formCarrito = new FormCarrito();
            formCarrito.Show();
            this.Close();
        }
    }
}
