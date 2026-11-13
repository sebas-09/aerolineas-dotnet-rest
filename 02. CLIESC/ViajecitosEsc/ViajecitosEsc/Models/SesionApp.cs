using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViajecitosEsc.Models
{
    public static class SesionApp
    {
        public static int? IdUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        // Puedes agregar más propiedades según lo que guardes en sesión
    }
}
