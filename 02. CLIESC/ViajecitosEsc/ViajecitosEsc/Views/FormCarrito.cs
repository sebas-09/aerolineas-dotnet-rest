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
    public partial class FormCarrito : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private CarritoCompraViewModel _carrito;

        public FormCarrito()
        {
            InitializeComponent();
            CargarCarrito();
        }

        private void CargarCarrito()
        {
            // Aquí deberías cargar el carrito desde una variable estática, archivo, o base de datos local
            _carrito = CarritoSesion.Carrito ?? new CarritoCompraViewModel
            {
                IdUsuario = SesionApp.IdUsuario ?? 0,
                Vuelos = new List<VueloCarritoItemViewModel>()
            };

            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = _carrito.Vuelos;
            lblTotal.Text = $"Total: {_carrito.Vuelos.Sum(x => x.Valor * x.CantidadBoletos):C}";
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow?.DataBoundItem is VueloCarritoItemViewModel item)
            {
                _carrito.Vuelos.Remove(item);
                CarritoSesion.Carrito = _carrito;
                CargarCarrito();
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (_carrito.Vuelos.Count == 0)
            {
                lblError.Text = "El carrito está vacío.";
                return;
            }

            // Validación: no permitir comprar boletos con diferentes ciudades de origen o destino en la misma fecha (ignorando la hora)
            var gruposPorFecha = _carrito.Vuelos
                .GroupBy(v => DateTime.Parse(v.HoraSalida).Date);

            foreach (var grupo in gruposPorFecha)
            {
                var origenes = grupo.Select(v => v.CiudadOrigen).Distinct().Count();
                var destinos = grupo.Select(v => v.CiudadDestino).Distinct().Count();

                if (origenes > 1 || destinos > 1)
                {
                    MessageBox.Show(
                        "No puedes comprar boletos con diferentes ciudades de origen o destino en la misma fecha. Por favor, revisa las fechas de tus boletos.",
                        "Validación de Carrito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            var formPago = new FormPagoCarrito(_carrito);
            formPago.ShowDialog();
            CargarCarrito(); // Por si se vació el carrito tras el pago
            this.Close();
        }

        private void btnAgregarVuelo_Click(object sender, EventArgs e)
        {
            var buscar = new FormBuscarVuelos();
            buscar.Show();
            this.Close();
        }

        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
