using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Entities
{
    public class FarmacoEntity
    {
        //nombre,descripcion,casa_productora,precio,existencia
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CasaProductora { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
    }
}
