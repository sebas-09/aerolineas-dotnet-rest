using System;

namespace Viajecitos_WebCliente.Models
{
    public class VueloViewModel
    {
        public int IdVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime HoraSalida { get; set; }
    }
}
