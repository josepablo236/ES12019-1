using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class AlbumViewModel
    {
        public string Nombre { get; set; }
        public Dictionary<string,EquipoViewModel> Equipos { get; set; }
        public Dictionary<string,EstampitaViewModel> EstampitasEspeciales { get; set; }
    }
}
