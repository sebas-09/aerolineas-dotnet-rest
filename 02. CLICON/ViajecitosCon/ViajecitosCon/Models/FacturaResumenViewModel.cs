namespace ViajecitosEsc.Models
{
    public class FacturaResumenViewModel
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal TotalFinal { get; set; }
        public int CantidadBoletos { get; set; }
        public string Descripcion { get; set; }
    }
}
