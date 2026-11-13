using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    [Table("Boleto")]
    public class Boleto
    {
        [Key]
        public int IdBoleto { get; set; }
        public int IdCompra { get; set; }
        public int IdVuelo { get; set; }
        public string NombreComprador { get; set; }
        public string ApellidoComprador { get; set; }
        public Compra Compra { get; set; }
        public Vuelo Vuelo { get; set; }
    }
}
