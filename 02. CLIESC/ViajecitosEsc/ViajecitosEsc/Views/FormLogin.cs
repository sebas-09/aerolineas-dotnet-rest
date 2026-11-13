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
    public partial class FormLogin : Form
    {

        private readonly ApiService _apiService = new ApiService(new HttpClient());
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        public async void btnLogin_Click(object sender, EventArgs e)
        {
            var model = new LoginViewModel
            {
                Email = txtCorreo.Text,
                Contraseña = txtContrasena.Text
            };

            var usuario = await _apiService.LoginAsync(model);
            if (usuario == null)
            {
                lblError.Text = "Correo o contraseña incorrectos.";
                return;
            }

            SesionApp.IdUsuario = usuario.IdUsuario;
            SesionApp.Nombre = usuario.Nombre;
            SesionApp.Apellido = usuario.Apellido;


            // Abre el menú principal y cierra el login
            var menu = new FormMenu();
            menu.Show();
            this.Hide();
        }
    }
}
