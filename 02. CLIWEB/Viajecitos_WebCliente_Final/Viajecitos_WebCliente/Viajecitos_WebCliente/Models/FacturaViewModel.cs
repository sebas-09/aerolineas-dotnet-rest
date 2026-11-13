using System;
using System.Collections.Generic;

namespace Viajecitos_WebCliente.Models
{
    public class FacturaViewModel
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Empleado { get; set; }
        public string MetodoPago { get; set; }
        public decimal TarifaUnitario { get; set; }
        public int CantidadBoletos { get; set; }
        public decimal TotalParcial { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalFinal { get; set; }
        public string Descripcion { get; set; }
        public UsuarioFacturaDto Usuario { get; set; }
        public string NombreUsuario => Usuario?.Nombre ?? "";
        public string ApellidoUsuario => Usuario?.Apellido ?? "";
        public string TelefonoUsuario => Usuario?.Telefono ?? "";

        // --- AGREGA ESTO ---
        public List<AmortizacionFilaViewModel> TablaAmortizacion { get; set; }
    }
}
