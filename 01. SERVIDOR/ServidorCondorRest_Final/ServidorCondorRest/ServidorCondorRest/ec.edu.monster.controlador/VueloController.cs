using Microsoft.AspNetCore.Mvc;
using ServidorCondorRest.ec.edu.monster.modelo;

namespace ServidorCondorRest.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class VueloController : ControllerBase
    {
        private readonly AerolineasCondorContext _context;
        public VueloController(AerolineasCondorContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetVuelo(int id)
        {
            var vuelo = _context.Vuelos.Find(id);
            if (vuelo == null) return NotFound();
            return Ok(vuelo);
        }

        [HttpGet("origenes")]
        public IActionResult GetCiudadesOrigen()
        {
            var origenes = _context.Vuelos
                .Select(v => v.CiudadOrigen)
                .Distinct()
                .ToList();
            return Ok(origenes);
        }

        [HttpGet("destinos")]
        public IActionResult GetCiudadesDestino([FromQuery] string origen)
        {
            var destinos = _context.Vuelos
                .Where(v => v.CiudadOrigen == origen)
                .Select(v => v.CiudadDestino)
                .Distinct()
                .ToList();
            return Ok(destinos);
        }

        [HttpGet]
        public IActionResult BuscarVuelos([FromQuery] string origen, [FromQuery] string destino, [FromQuery] DateTime horaSalida)
        {
            var vuelos = _context.Vuelos
                .Where(v => v.CiudadOrigen == origen && v.CiudadDestino == destino && v.HoraSalida.Date == horaSalida.Date)
                .ToList();
            return Ok(vuelos);
        }
    }
}
