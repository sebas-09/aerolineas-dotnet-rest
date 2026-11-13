using System.Collections.Generic;

namespace ViajecitosEsc.Models
{
    public class CarritoCompraViewModel
    {
        public int IdUsuario { get; set; }
        public List<VueloCarritoItemViewModel> Vuelos { get; set; } = new();
        public PagoViewModel Pago { get; set; } = new();
        public string TipoAmortizacion { get; set; } // "alemana" o "francesa"
        public List<AmortizacionFilaViewModel> TablaAmortizacion { get; set; } = new();
        public decimal TotalCarrito { get; set; }
    }

    public class VueloCarritoItemViewModel
    {
        public int IdVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public decimal Valor { get; set; }
        public string HoraSalida { get; set; }
        public int CantidadBoletos { get; set; }
    }


}
