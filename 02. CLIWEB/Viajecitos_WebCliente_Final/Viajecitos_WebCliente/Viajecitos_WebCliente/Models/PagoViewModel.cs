namespace Viajecitos_WebCliente.Models
{
    public class PagoViewModel
    {
        public string TipoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CodigoSeguridad { get; set; }
        public bool? Diferido { get; set; }
        public int? MesesDiferido { get; set; }
        public decimal? Saldo { get; set; }

        // Nuevo campo (opcional, si prefieres pasarlo aquí):
         public string TipoAmortizacion { get; set; } // "alemana" o "francesa"
    }
}
