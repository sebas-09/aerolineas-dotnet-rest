using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    [Table("Vuelo")]
    public class Vuelo
    {
        [Key]
        public int IdVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public decimal Valor { get; set; }
        public DateTime HoraSalida { get; set; }
        public ICollection<Boleto> Boletos { get; set; }
    }
}
