using Microsoft.AspNetCore.Mvc;
using Viajecitos_WebCliente.Models;
using Viajecitos_WebCliente.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Viajecitos_WebCliente.Controllers
{
    public class VuelosController : Controller
    {
        private readonly ApiService _apiService;

        public VuelosController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Mostrar formulario de búsqueda
        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var model = new VuelosBuscarViewModel();
            var origenes = await _apiService.GetOrigenesAsync();
            model.Origenes = origenes.Select(o => new SelectListItem { Value = o, Text = o }).ToList();
            model.Vuelos = new List<VueloViewModel>();
            model.BuscarRealizada = false;
            return View(model);
        }

        // POST: Procesar búsqueda y mostrar tabla de resultados
        [HttpPost]
        public async Task<IActionResult> Buscar(VuelosBuscarViewModel model)
        {
            var origenes = await _apiService.GetOrigenesAsync();
            model.Origenes = origenes.Select(o => new SelectListItem { Value = o, Text = o }).ToList();

            if (!string.IsNullOrEmpty(model.Origen))
            {
                var destinos = await _apiService.GetDestinosAsync(model.Origen);
                model.Destinos = destinos.Select(d => new SelectListItem { Value = d, Text = d }).ToList();
            }

            if (!string.IsNullOrEmpty(model.Origen) && !string.IsNullOrEmpty(model.Destino))
            {
                model.Vuelos = await _apiService.BuscarVuelosAsync(model.Origen, model.Destino, model.Fecha);
            }
            else
            {
                model.Vuelos = new List<VueloViewModel>();
            }

            model.BuscarRealizada = true;
            return View(model);
        }

        // AJAX: Obtener destinos en base al origen
        [HttpGet]
        public async Task<IActionResult> GetDestinos(string origen)
        {
            var destinos = await _apiService.GetDestinosAsync(origen);
            return Json(destinos);
        }

        // GET: Mostrar formulario de compra
        [HttpGet]
        public IActionResult Comprar(int idVuelo)
        {
            int? usuarioId = HttpContext.Session.GetInt32("IdUsuario");
            if (usuarioId == null)
                return RedirectToAction("Login", "Account");

            var model = new CompraViewModel
            {
                IdVuelo = idVuelo,
                IdUsuario = usuarioId.Value,
                CantidadBoletos = 1,
                Pago = new PagoViewModel()
            };
            return View(model);
        }

        // POST: Procesar compra y mostrar éxito
        [HttpPost]
        public async Task<IActionResult> Comprar(CompraViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var factura = await _apiService.ComprarAsync(model);

            if (factura == null)
            {
                ViewBag.Error = "Error al realizar la compra. Verifica los datos e inténtalo nuevamente.";
                return View(model);
            }

            return View("Exito", factura);
        }
    }
}
