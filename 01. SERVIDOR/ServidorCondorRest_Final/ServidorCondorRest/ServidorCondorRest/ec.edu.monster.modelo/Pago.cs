using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    [Table("Pago")]
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public int IdCompra { get; set; }
        public string TipoTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroTarjeta { get; set; }
        public string CodigoSeguridad { get; set; }
        public bool? Diferido { get; set; }
        public int? MesesDiferido { get; set; }
        public decimal? Saldo { get; set; }
        public Compra Compra { get; set; }
    }
}
