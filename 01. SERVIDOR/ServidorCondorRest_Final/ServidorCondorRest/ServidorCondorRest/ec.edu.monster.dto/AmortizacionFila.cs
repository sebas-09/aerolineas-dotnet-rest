namespace ServidorCondorRest.ec.edu.monster.dto
{
    public class AmortizacionFilaDto
    {
        public int Mes { get; set; }
        public decimal Cuota { get; set; }
        public decimal Interes { get; set; }
        public decimal Amortizacion { get; set; }
        public decimal Saldo { get; set; }
    }

}
