using Microsoft.AspNetCore.Mvc;
using ServidorCondorRest.ec.edu.monster.modelo;
using ServidorCondorRest.ec.edu.monster.dto;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace ServidorCondorRest.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly AerolineasCondorContext _context;
        public CompraController(AerolineasCondorContext context)
        {
            _context = context;
        }

        [HttpPost("comprar")]
        public IActionResult Comprar([FromBody] CompraVariosRequest request)
        {
            var usuario = _context.Usuarios.Find(request.IdUsuario);
            if (usuario == null) return BadRequest("Usuario no encontrado.");

            // OBTÉN LOS VUELOS SOLICITADOS
            var vuelosIds = request.Vuelos.Select(v => v.IdVuelo).ToList();
            var vuelos = _context.Vuelos.Where(v => vuelosIds.Contains(v.IdVuelo)).ToList();

            // VALIDACIÓN: ¿Hay algún vuelo en el pasado?
            var now = DateTime.Now;
            var vueloInvalido = vuelos.FirstOrDefault(v => v.HoraSalida < now);
            if (vueloInvalido != null)
            {
                return BadRequest("No se pueden comprar vuelos con fecha/hora inferior a la actual.");
            }

            var compra = new Compra
            {
                IdUsuario = usuario.IdUsuario,
                FechaCompra = DateTime.Now,
                MetodoPago = request.Pago.TipoTarjeta,
                Empleado = "Sistema"
            };
            _context.Compras.Add(compra);
            _context.SaveChanges();

            decimal subtotal = 0;
            var vuelosDesc = new List<string>();

            foreach (var v in request.Vuelos)
            {
                var vuelo = vuelos.First(x => x.IdVuelo == v.IdVuelo);
                vuelosDesc.Add($"{vuelo.CiudadOrigen}-{vuelo.CiudadDestino}, Vuelo {vuelo.IdVuelo} x{v.CantidadBoletos}");

                for (int i = 0; i < v.CantidadBoletos; i++)
                {
                    _context.Boletos.Add(new Boleto
                    {
                        IdCompra = compra.IdCompra,
                        IdVuelo = vuelo.IdVuelo,
                        NombreComprador = usuario.Nombre,
                        ApellidoComprador = usuario.Apellido
                    });
                }
                subtotal += (vuelo.Valor * v.CantidadBoletos);
            }

            var pago = new Pago
            {
                IdCompra = compra.IdCompra,
                TipoTarjeta = request.Pago.TipoTarjeta,
                NombreTitular = request.Pago.NombreTitular,
                NumeroTarjeta = request.Pago.NumeroTarjeta,
                CodigoSeguridad = request.Pago.CodigoSeguridad,
                Diferido = request.Pago.Diferido,
                MesesDiferido = request.Pago.MesesDiferido,
                Saldo = request.Pago.Saldo
            };
            _context.Pagos.Add(pago);

            decimal impuesto = subtotal * 0.15m;
            decimal total = subtotal + impuesto;

            string descripcion = string.Join("; ", vuelosDesc);

            // CALCULA LA TABLA SI HAY DIFERIDO
            List<AmortizacionFilaDto> tablaAmortizacion = null;
            string tablaJson = null;
            if (pago.Diferido == true && pago.MesesDiferido > 0 && !string.IsNullOrEmpty(request.TipoAmortizacion))
            {
                tablaAmortizacion = AmortizacionHelper.Calcular(request.TipoAmortizacion, total, pago.MesesDiferido.Value, 0.15m);
                tablaJson = JsonSerializer.Serialize(tablaAmortizacion);
            }

            var factura = new Factura
            {
                IdCompra = compra.IdCompra,
                FechaFactura = DateTime.Now,
                TarifaUnitario = subtotal,
                CantidadBoletos = request.Vuelos.Sum(v => v.CantidadBoletos),
                Impuesto = impuesto,
                TotalParcial = subtotal,
                TotalFinal = total,
                Descripcion = descripcion,
                AmortizacionJson = tablaJson // <--- GUARDA LA TABLA COMO JSON
            };
            _context.Facturas.Add(factura);

            _context.SaveChanges();

            return Ok(new
            {
                factura.IdFactura,
                factura.TotalFinal,
                TablaAmortizacion = tablaAmortizacion
            });
        }
    }
}
