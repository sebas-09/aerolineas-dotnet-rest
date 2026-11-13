using Microsoft.AspNetCore.Mvc;
using ServidorCondorRest.ec.edu.monster.dto;

namespace ServidorCondorRest.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmortizacionController : ControllerBase
    {
        [HttpPost]
        public IActionResult Calcular([FromBody] AmortizacionCalcRequest req)
        {
            var tabla = AmortizacionHelper.Calcular(req.tipo, req.total, req.meses, 0.15m);
            return Ok(tabla);
        }
        public class AmortizacionCalcRequest
        {
            public decimal total { get; set; }
            public int meses { get; set; }
            public string tipo { get; set; }
        }
    }

}
