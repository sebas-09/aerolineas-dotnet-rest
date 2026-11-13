using System.Collections.Generic;

namespace ServidorCondorRest.ec.edu.monster.dto
{
    public class CompraRequest
    {
        public int IdUsuario { get; set; }
        public List<VueloCompraRequest> Vuelos { get; set; }
        public PagoRequest Pago { get; set; }
        public string? TipoAmortizacion { get; set; } // "alemana" o "francesa"
    }
}
