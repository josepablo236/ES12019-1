using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ArbolBinarioUtils
{
    public class Nodo<T>
    {
        public Nodo<T> Izquierda { get; set; }
        public Nodo<T> Derecha { get; set; }
        public T Valor { get; set; }
        public string Llave { get; set; }
    }
}
