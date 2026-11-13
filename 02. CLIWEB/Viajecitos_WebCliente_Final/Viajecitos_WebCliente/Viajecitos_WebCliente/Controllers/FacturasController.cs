using Microsoft.AspNetCore.Mvc;
using Viajecitos_WebCliente.Models;
using Viajecitos_WebCliente.Servicios;

namespace Viajecitos_WebCliente.Controllers
{
    public class FacturasController : Controller
    {
        private readonly ApiService _apiService;
        public FacturasController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Formulario para consultar factura
        public IActionResult Consultar()
        {
            return View();
        }

        // POST: Buscar factura por ID
        [HttpPost]
        public async Task<IActionResult> Consultar(int idFactura)
        {
            var factura = await _apiService.GetFacturaAsync(idFactura);
            if (factura == null)
            {
                ViewBag.Error = $"No existe factura con el código {idFactura}.";
                return View();
            }
            return View("FacturaFinal", factura); // Usa FacturaFinal, no Detalle
        }

        // GET: Mostrar detalle por URL directa
        public async Task<IActionResult> FacturaFinal(int id)
        {
            var factura = await _apiService.GetFacturaAsync(id);
            if (factura == null)
            {
                ViewBag.Error = $"No existe factura con el código {id}.";
                return View("Consultar");
            }
            return View(factura); // Usa FacturaFinal.cshtml
        }

        [HttpGet]
        public async Task<IActionResult> DescargarPdf(int id)
        {
            var factura = await _apiService.GetFacturaAsync(id);
            if (factura == null)
                return NotFound("Factura no encontrada");

            var pdf = FacturaPdfService.GenerarPdf(factura);
            var nombreArchivo = $"Factura_{factura.IdFactura}.pdf";
            return File(pdf, "application/pdf", nombreArchivo);
        }

        public async Task<IActionResult> Historial()
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
                return RedirectToAction("Login", "Account");
            var historial = await _apiService.GetHistorialComprasAsync(idUsuario.Value);
            return View(historial);
        }
    }
}
