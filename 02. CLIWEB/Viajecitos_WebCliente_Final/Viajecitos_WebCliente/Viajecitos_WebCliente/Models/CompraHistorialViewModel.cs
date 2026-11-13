namespace Viajecitos_WebCliente.Models
{
    public class CompraHistorialViewModel
    {
        public string NombreUsuario { get; set; }
        public int NumeroBoletos { get; set; }
        public DateTime FechaCompra { get; set; }
        public int IdFactura { get; set; }
        public string Descripcion { get; set; } // Usado para el detalle de vuelos
    }


}
