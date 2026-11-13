namespace ViajecitosEsc.Models
{
    public class CompraViewModel
    {
        public int IdUsuario { get; set; }
        public int IdVuelo { get; set; }
        public int CantidadBoletos { get; set; }
        public PagoViewModel Pago { get; set; }
    }
}
