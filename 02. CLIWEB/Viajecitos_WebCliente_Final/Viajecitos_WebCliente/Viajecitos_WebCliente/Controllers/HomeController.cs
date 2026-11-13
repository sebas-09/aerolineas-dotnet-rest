using Microsoft.AspNetCore.Mvc;

namespace Viajecitos_WebCliente.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Menu()
        {
            // Usa Session para mostrar nombre y apellido
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            ViewBag.Apellido = HttpContext.Session.GetString("Apellido");
            return View();
        }
    }
}