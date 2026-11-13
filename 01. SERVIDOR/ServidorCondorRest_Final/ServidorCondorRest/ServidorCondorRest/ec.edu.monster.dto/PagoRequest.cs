namespace ServidorCondorRest.ec.edu.monster.dto
{
    public class PagoRequest
    {
        public string TipoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CodigoSeguridad { get; set; }
        public bool? Diferido { get; set; }
        public int? MesesDiferido { get; set; }
        public decimal? Saldo { get; set; }
    }
}
