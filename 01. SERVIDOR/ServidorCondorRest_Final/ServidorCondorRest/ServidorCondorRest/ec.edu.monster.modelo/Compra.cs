using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public string MetodoPago { get; set; }
        public string Empleado { get; set; }
        public Usuario Usuario { get; set; }
        public ICollection<Boleto> Boletos { get; set; }
        public Factura? Factura { get; set; }
        public Pago? Pago { get; set; }
    }
}
