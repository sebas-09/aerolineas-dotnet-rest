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

namespace ViajecitosEsc.Views
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            lblUsuario.Text = $"Bienvenido, {SesionApp.Nombre} {SesionApp.Apellido}";
        }

        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            var buscar = new FormBuscarVuelos();
            buscar.Show();
            this.Hide();
        }

        private void btnCarrito_Click(object sender, EventArgs e)
        {
            var carrito = new FormCarrito();
            carrito.Show();
            this.Hide();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            var facturas = new FormConsultarFactura();
            facturas.Show();
            this.Hide();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            var historial = new FormHistorial();
            historial.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SesionApp.IdUsuario = null;
            SesionApp.Nombre = null;
            SesionApp.Apellido = null;
            var login = new FormLogin();
            login.Show();
            this.Close();
        }
    }
}
