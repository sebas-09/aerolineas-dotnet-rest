using System;
using System.Collections.Generic;
using System.Linq;

namespace ViajecitosCon.Models
{
    public class VueloCarritoItem
    {
        public int IdVuelo { get; set; }
        public string CiudadOrigen { get; set; }
        public string CiudadDestino { get; set; }
        public DateTime HoraSalida { get; set; }
        public decimal Valor { get; set; }
        public int CantidadBoletos { get; set; }
    }

    public class CarritoCompraConsola
    {
        public List<VueloCarritoItem> Vuelos { get; set; } = new();

        public void AgregarVuelo(VueloCarritoItem item)
        {
            var existente = Vuelos.FirstOrDefault(v =>
                v.IdVuelo == item.IdVuelo &&
                v.HoraSalida == item.HoraSalida);

            if (existente != null)
                existente.CantidadBoletos += item.CantidadBoletos;
            else
                Vuelos.Add(item);
        }

        public decimal Total => Vuelos.Sum(v => v.Valor * v.CantidadBoletos);

        // Validación de reglas de compra
        public bool EsCompraValida(out string mensajeError)
        {
            mensajeError = "";

            var gruposPorFecha = Vuelos.GroupBy(v => v.HoraSalida.Date);

            foreach (var grupo in gruposPorFecha)
            {
                var origenes = grupo.Select(v => v.CiudadOrigen).Distinct().Count();
                var destinos = grupo.Select(v => v.CiudadDestino).Distinct().Count();

                // Si hay más de un origen o más de un destino en la misma fecha, no es válido
                if (origenes > 1 || destinos > 1)
                {
                    mensajeError = $"No puedes comprar boletos con diferentes ciudades de origen o destino en la misma fecha ({grupo.Key:yyyy-MM-dd}).";
                    return false;
                }
            }
            return true;
        }
    }
}