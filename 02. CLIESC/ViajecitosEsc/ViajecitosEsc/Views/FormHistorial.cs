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
    public partial class FormHistorial : Form
    {
        private readonly ApiService _apiService = new ApiService(new HttpClient());

        public FormHistorial()
        {
            InitializeComponent();
            CargarHistorial();

            // Asocia el evento del botón regresar al menú
            btnRegresarMenu.Click += btnRegresarMenu_Click;

            // Asocia el evento de doble clic en la tabla
            dgvHistorial.CellDoubleClick += dgvHistorial_CellDoubleClick;
        }

        private async void CargarHistorial()
        {
            lblError.Text = "";
            dgvHistorial.DataSource = null;

            int? idUsuario = SesionApp.IdUsuario;
            if (idUsuario == null)
            {
                lblError.Text = "Debe iniciar sesión.";
                return;
            }

            var historial = await _apiService.GetHistorialAsync(idUsuario.Value);
            if (historial == null || historial.Count == 0)
            {
                lblError.Text = "No hay facturas registradas.";
                return;
            }

            dgvHistorial.DataSource = historial;

            // Configura los encabezados de las columnas relevantes
            if (dgvHistorial.Columns.Contains("IdFactura"))
                dgvHistorial.Columns["IdFactura"].HeaderText = "Factura";
            if (dgvHistorial.Columns.Contains("FechaFactura"))
                dgvHistorial.Columns["FechaFactura"].HeaderText = "Fecha";
            if (dgvHistorial.Columns.Contains("CantidadBoletos"))
                dgvHistorial.Columns["CantidadBoletos"].HeaderText = "Boletos";
            if (dgvHistorial.Columns.Contains("TotalFinal"))
                dgvHistorial.Columns["TotalFinal"].HeaderText = "Total";
            if (dgvHistorial.Columns.Contains("Descripcion"))
                dgvHistorial.Columns["Descripcion"].HeaderText = "Descripción";
            if (dgvHistorial.Columns.Contains("MetodoPago"))
                dgvHistorial.Columns["MetodoPago"].HeaderText = "Método de Pago";

            // Oculta columnas innecesarias si existen
            if (dgvHistorial.Columns.Contains("IdUsuario"))
                dgvHistorial.Columns["IdUsuario"].Visible = false;
            if (dgvHistorial.Columns.Contains("Usuario"))
                dgvHistorial.Columns["Usuario"].Visible = false;
            if (dgvHistorial.Columns.Contains("TablaAmortizacion"))
                dgvHistorial.Columns["TablaAmortizacion"].Visible = false;
        }

        private void FormHistorial_Load(object sender, EventArgs e)
        {

        }

        private void dgvHistorial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvHistorial.Rows[e.RowIndex].DataBoundItem as FacturaResumenViewModel;
                if (row != null)
                {
                    MessageBox.Show("Abriendo detalle de factura: " + row.IdFactura);
                    var detalle = new FormDetalleFactura(row.IdFactura);
                    detalle.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la factura seleccionada.");
                }
            }
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            var formMenu = new FormMenu();
            formMenu.Show();
            this.Close();
        }
    }
}