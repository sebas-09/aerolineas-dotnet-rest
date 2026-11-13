using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ViajecitosEsc.Models
{
    public class VuelosBuscarViewModel
    {
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now.Date;
        public List<SelectListItem> Origenes { get; set; } = new();
        public List<SelectListItem> Destinos { get; set; } = new();
        public List<VueloViewModel> Vuelos { get; set; }
        public bool BuscarRealizada { get; set; } = false;
    }
}
