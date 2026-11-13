using System;
using System.Collections.Generic;

namespace ServidorCondorRest.ec.edu.monster.dto
{
    public static class AmortizacionHelper
    {
        public static List<AmortizacionFilaDto> Calcular(string tipo, decimal total, int meses, decimal tasaAnual)
        {
            var tabla = new List<AmortizacionFilaDto>();
            if (meses <= 0) return tabla;
            decimal tasaMensual = tasaAnual / 12;
            decimal saldo = total;

            if (tipo == "alemana")
            {
                decimal amortizacionConstante = total / meses;
                for (int mes = 1; mes <= meses; mes++)
                {
                    decimal interes = saldo * tasaMensual;
                    decimal cuota = amortizacionConstante + interes;
                    saldo -= amortizacionConstante;
                    tabla.Add(new AmortizacionFilaDto
                    {
                        Mes = mes,
                        Cuota = decimal.Round(cuota, 2),
                        Interes = decimal.Round(interes, 2),
                        Amortizacion = decimal.Round(amortizacionConstante, 2),
                        Saldo = decimal.Round(saldo < 0 ? 0 : saldo, 2)
                    });
                }
            }
            else // francesa
            {
                decimal r = tasaMensual;
                decimal cuota = (r > 0)
                    ? (total * (r * (decimal)Math.Pow((double)(1 + r), meses)) / ((decimal)Math.Pow((double)(1 + r), meses) - 1))
                    : total / meses;
                for (int mes = 1; mes <= meses; mes++)
                {
                    decimal interes = saldo * r;
                    decimal amortizacion = cuota - interes;
                    saldo -= amortizacion;
                    tabla.Add(new AmortizacionFilaDto
                    {
                        Mes = mes,
                        Cuota = decimal.Round(cuota, 2),
                        Interes = decimal.Round(interes, 2),
                        Amortizacion = decimal.Round(amortizacion, 2),
                        Saldo = decimal.Round(saldo < 0 ? 0 : saldo, 2)
                    });
                }
            }
            return tabla;
        }
    }

}
