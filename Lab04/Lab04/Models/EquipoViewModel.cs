using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class EquipoViewModel
    {
        public string Nombre { get; set; }
        public int CantidadTotal { get; set; }
        public bool Completo { get; set; }
        public Dictionary<string, EstampitaViewModel> Estampitas{ get; set; }
    }
}
