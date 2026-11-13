using Microsoft.AspNetCore.Mvc;
using Viajecitos_WebCliente.Models;
using Viajecitos_WebCliente.Servicios;
using Microsoft.AspNetCore.Mvc.Rendering;
using Viajecitos_WebCliente.Helpers;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Viajecitos_WebCliente.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApiService _apiService;
        private const string SessionCarrito = "Carrito";

        public CarritoController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            var carrito = HttpContext.Session.GetObject<CarritoCompraViewModel>(SessionCarrito) ?? new CarritoCompraViewModel
            {
                IdUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0
            };
            carrito.TotalCarrito = carrito.Vuelos.Sum(x => x.Valor * x.CantidadBoletos);
            HttpContext.Session.SetObject(SessionCarrito, carrito);
            return View(carrito);
        }

        [HttpPost]
        public IActionResult AgregarVuelo(VueloCarritoItemViewModel item)
        {
            var carrito = HttpContext.Session.GetObject<CarritoCompraViewModel>(SessionCarrito) ?? new CarritoCompraViewModel
            {
                IdUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0
            };
            var existente = carrito.Vuelos.FirstOrDefault(x => x.IdVuelo == item.IdVuelo);
            if (existente != null)
                existente.CantidadBoletos += item.CantidadBoletos;
            else
                carrito.Vuelos.Add(item);
            HttpContext.Session.SetObject(SessionCarrito, carrito);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult QuitarVuelo(int idVuelo)
        {
            var carrito = HttpContext.Session.GetObject<CarritoCompraViewModel>(SessionCarrito);
            if (carrito != null)
            {
                carrito.Vuelos.RemoveAll(x => x.IdVuelo == idVuelo);
                HttpContext.Session.SetObject(SessionCarrito, carrito);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Pago()
        {
            var carrito = HttpContext.Session.GetObject<CarritoCompraViewModel>(SessionCarrito);
            if (carrito == null || carrito.Vuelos.Count == 0)
                return RedirectToAction("Index");
            carrito.TotalCarrito = carrito.Vuelos.Sum(x => x.Valor * x.CantidadBoletos);
            ViewBag.TotalCarrito = carrito.TotalCarrito;
            ViewBag.TipoAmortizacionList = new List<SelectListItem>
            {
                new SelectListItem { Value = "alemana", Text = "Alemana (cuotas fijas)" },
                new SelectListItem { Value = "francesa", Text = "Francesa (amortización fija)" }
            };
            return View(carrito);
        }

        // Método que maneja la compra y muestra errores del backend (como vuelos en el pasado)
        [HttpPost]
        public async Task<IActionResult> ConfirmarPago(CarritoCompraViewModel model)
        {
            model.IdUsuario = HttpContext.Session.GetInt32("IdUsuario") ?? 0;
            var carrito = HttpContext.Session.GetObject<CarritoCompraViewModel>(SessionCarrito);
            if (carrito == null || carrito.Vuelos.Count == 0)
                return RedirectToAction("Index");
            model.Vuelos = carrito.Vuelos;
            model.TotalCarrito = model.Vuelos.Sum(x => x.Valor * x.CantidadBoletos);

            // Llama al método que construye dinámicamente el JSON y recibe error del backend
            var resultado = await _apiService.ComprarConResultadoAsync(model);

            if (!string.IsNullOrWhiteSpace(resultado.Error))
            {
                // Limpia el mensaje (puede venir entre comillas o como JSON)
                var msg = resultado.Error.Trim('"');
                if (msg.Contains("No se pueden comprar vuelos"))
                    msg = "No se pueden comprar vuelos con fecha/hora inferior a la actual.";
                if (msg.Contains("TipoAmortizacion"))
                    msg = "El campo tipo de amortización es requerido sólo si paga con crédito y diferido.";

                ViewBag.Error = msg;
                ViewBag.TotalCarrito = model.TotalCarrito;
                return View("Pago", model);
            }

            if (resultado.Factura == null)
            {
                ViewBag.Error = "No se pudo realizar la compra. Inténtalo nuevamente.";
                ViewBag.TotalCarrito = model.TotalCarrito;
                return View("Pago", model);
            }

            // Refresca datos completos de la factura para la vista detallada
            var factura = await _apiService.GetFacturaAsync(resultado.Factura.IdFactura);

            // Asegura la tabla de amortización (si se retorna en la respuesta inicial)
            if (factura != null && resultado.Factura.TablaAmortizacion != null)
                factura.TablaAmortizacion = resultado.Factura.TablaAmortizacion;

            HttpContext.Session.Remove(SessionCarrito);

            // Muestra la vista FacturaFinal (la ruta completa)
            return View("~/Views/Facturas/FacturaFinal.cshtml", factura);
        }

        // AJAX: Calcula la tabla de amortización para mostrar en la pantalla de pago
        [HttpPost]
        public async Task<JsonResult> CalcularAmortizacion(decimal total, int meses, string tipo)
        {
            var tabla = await _apiService.CalcularAmortizacionAsync(total, meses, tipo);
            return Json(tabla);
        }
    }
}
