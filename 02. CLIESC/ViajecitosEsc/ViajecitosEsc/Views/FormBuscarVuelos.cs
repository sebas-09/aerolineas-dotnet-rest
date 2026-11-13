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
    public partial class FormBuscarVuelos : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());
        private List<VueloViewModel> vuelosActuales = new List<VueloViewModel>();
        public FormBuscarVuelos()
        {
            InitializeComponent();
            dtpFecha.MinDate = DateTime.Now.Date; // <-- Línea agregada
            CargarOrigenes();
            dtpFecha.Value = DateTime.Now.Date;
            if (!dgvVuelos.Columns.Contains("Cantidad"))
            {
                var colCantidad = new DataGridViewTextBoxColumn
                {
                    Name = "Cantidad",
                    HeaderText = "Cantidad",
                    ValueType = typeof(int),
                    Width = 70
                };
                dgvVuelos.Columns.Add(colCantidad);
            }
        }

        private async void CargarOrigenes()
        {
            var origenes = await _apiService.GetOrigenesAsync();
            cmbOrigen.DataSource = origenes;
            cmbOrigen.SelectedIndex = -1;
            cmbDestino.DataSource = null;
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem is not string origen || cmbDestino.SelectedItem is not string destino)
            {
                MessageBox.Show("Seleccione origen y destino.");
                return;
            }

            var fecha = dtpFecha.Value.Date;
            vuelosActuales = await _apiService.BuscarVuelosAsync(origen, destino, fecha);

            dgvVuelos.DataSource = vuelosActuales;
            dgvVuelos.ClearSelection();

            // Inicializa la columna de cantidad en 1 para cada fila
            foreach (DataGridViewRow row in dgvVuelos.Rows)
            {
                if (!row.IsNewRow)
                    row.Cells["Cantidad"].Value = 1;
            }
        }

        private async void cmbOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedItem is string origen)
            {
                var destinos = await _apiService.GetDestinosAsync(origen);
                cmbDestino.DataSource = destinos;
                cmbDestino.SelectedIndex = -1;
            }
        }

        private void cmbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.CurrentRow?.DataBoundItem is VueloViewModel vuelo)
            {
                // Obtén o crea el carrito
                var carrito = CarritoSesion.Carrito ?? new CarritoCompraViewModel
                {
                    IdUsuario = SesionApp.IdUsuario ?? 0,
                    Vuelos = new List<VueloCarritoItemViewModel>()
                };

                // Obtén la cantidad seleccionada (asegúrate de tener nudCantidad en el formulario)
                int cantidad = 1;
                var cellValue = dgvVuelos.CurrentRow.Cells["Cantidad"].Value;
                if (cellValue == null || !int.TryParse(cellValue.ToString(), out cantidad) || cantidad < 1)
                {
                    MessageBox.Show("Ingrese una cantidad válida de boletos.");
                    return;
                }

                // Verifica si ya existe el vuelo en el carrito
                var existente = carrito.Vuelos.FirstOrDefault(v => v.IdVuelo == vuelo.IdVuelo);
                if (existente != null)
                {
                    existente.CantidadBoletos += cantidad;
                }
                else
                {
                    carrito.Vuelos.Add(new VueloCarritoItemViewModel
                    {
                        IdVuelo = vuelo.IdVuelo,
                        CiudadOrigen = vuelo.CiudadOrigen,
                        CiudadDestino = vuelo.CiudadDestino,
                        Valor = vuelo.Valor,
                        HoraSalida = vuelo.HoraSalida.ToString("yyyy-MM-dd HH:mm"),
                        CantidadBoletos = cantidad
                    });
                }

                // Actualiza el total del carrito
                carrito.TotalCarrito = carrito.Vuelos.Sum(x => x.Valor * x.CantidadBoletos);

                // Guarda el carrito en sesión
                CarritoSesion.Carrito = carrito;

                // Abre el formulario del carrito y cierra este
                var formCarrito = new FormCarrito();
                formCarrito.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un vuelo para agregar al carrito.");
            }
        }

        private void FormBuscarVuelos_Load(object sender, EventArgs e)
        {

        }
    }
}
