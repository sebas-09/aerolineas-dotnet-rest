using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServidorCondorRest.ec.edu.monster.modelo
{
    [Table("Factura")]
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdCompra { get; set; }
        public DateTime FechaFactura { get; set; }
        public decimal TarifaUnitario { get; set; }
        public int CantidadBoletos { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalParcial { get; set; }
        public decimal TotalFinal { get; set; }
        public string Descripcion { get; set; }
        public string? AmortizacionJson { get; set; }  // <--- NUEVO
        public Compra Compra { get; set; }
    }
}
