using Microsoft.AspNetCore.Mvc;
using ServidorCondorRest.ec.edu.monster.modelo;
using System.Linq;

namespace ServidorCondorRest.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly AerolineasCondorContext _context;

        public FacturaController(AerolineasCondorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerFactura(int id)
        {
            var factura = _context.Facturas
                .Where(f => f.IdFactura == id)
                .Select(f => new
                {
                    f.IdFactura,
                    f.FechaFactura,
                    f.TotalFinal,
                    f.TotalParcial,
                    f.Impuesto,
                    f.TarifaUnitario,
                    f.CantidadBoletos,
                    f.Descripcion,
                    f.AmortizacionJson,
                    Empleado = f.Compra != null ? f.Compra.Empleado : "",
                    Usuario = f.Compra != null && f.Compra.Usuario != null ? new
                    {
                        Nombre = f.Compra.Usuario.Nombre ?? "",
                        Apellido = f.Compra.Usuario.Apellido ?? "",
                        Telefono = f.Compra.Usuario.Telefono ?? ""
                    } : null,
                    MetodoPago = f.Compra != null ? f.Compra.MetodoPago ?? "" : ""
                })
                .FirstOrDefault();

            if (factura == null)
                return NotFound("Factura no encontrada.");

            return Ok(factura);
        }

        [HttpGet("historial/{idUsuario}")]
        public IActionResult Historial(int idUsuario)
        {
            var compras = _context.Compras
                .Where(c => c.IdUsuario == idUsuario)
                .OrderByDescending(c => c.FechaCompra)
                .Select(c => new
                {
                    NombreUsuario = (c.Usuario != null ? c.Usuario.Nombre : "") + " " + (c.Usuario != null ? c.Usuario.Apellido : ""),
                    NumeroBoletos = c.Boletos != null ? c.Boletos.Count() : 0,
                    FechaCompra = c.FechaCompra,
                    IdFactura = c.Factura != null ? c.Factura.IdFactura : 0,
                    Descripcion = c.Boletos != null ? string.Join("; ", c.Boletos
                        .GroupBy(b => new { b.IdVuelo, b.Vuelo.CiudadOrigen, b.Vuelo.CiudadDestino })
                        .Select(g => $"{g.Key.CiudadOrigen}-{g.Key.CiudadDestino}, Vuelo {g.Key.IdVuelo} x{g.Count()}")) : ""
                })
                .ToList();

            return Ok(compras);
        }
    }
}
