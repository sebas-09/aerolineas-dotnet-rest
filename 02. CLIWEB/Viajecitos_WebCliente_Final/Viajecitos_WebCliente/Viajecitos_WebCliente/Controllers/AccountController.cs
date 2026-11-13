using Microsoft.AspNetCore.Mvc;
using Viajecitos_WebCliente.Models;
using Viajecitos_WebCliente.Servicios;

namespace Viajecitos_WebCliente.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiService _apiService;
        public AccountController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _apiService.LoginAsync(model);
            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos.";
                return View(model);
            }

            // Usa Session, no TempData
            HttpContext.Session.SetInt32("IdUsuario", usuario.IdUsuario);
            HttpContext.Session.SetString("Nombre", usuario.Nombre);
            HttpContext.Session.SetString("Apellido", usuario.Apellido);

            return RedirectToAction("Menu", "Home");
        }

        public IActionResult Logout()
        {
            // Limpia TempData y Session
            TempData.Clear();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}