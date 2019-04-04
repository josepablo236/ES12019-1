using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab04.Models
{
    public class EstampitaViewModel
    {
        public int Tipo { get; set; }
        public int No { get; set; }
        public int Cantidad { get; set; }
        public bool EstaEnAlbum { get; set; }
        public string Nombre { get; set; }
    }
}
