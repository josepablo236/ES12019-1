using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ArbolBinarioUtils
{
    public class ArbolBinario<T>
    {
        private Nodo<T> Raiz;

        public void Agregar(T valor, string nuevaLlave)
        {
            if(Raiz == null)
            {
                Nodo<T> nuevoNodo = new Nodo<T>();
                nuevoNodo.Valor = valor;
                nuevoNodo.Llave = nuevaLlave;
                Raiz = nuevoNodo;
            }
            else {
                Agregar(valor, nuevaLlave, Raiz);
            }
        }

        private void Agregar(T valor, string nuevaLlave, Nodo<T> nodo)
        {

            Nodo<T> tmp = nodo;
            //nuevaLlave < tmp.llave
            if (nuevaLlave.CompareTo(tmp.Llave) == -1)
            {
                if (tmp.Izquierda == null)
                {
                    Nodo<T> nuevoNodo = new Nodo<T>();
                    nuevoNodo.Valor = valor;
                    nuevoNodo.Llave = nuevaLlave;
                    tmp.Izquierda = nuevoNodo;
                }
                else
                {
                    Agregar(valor, nuevaLlave, tmp.Izquierda);
                }
            }
            else
            {
                if (tmp.Derecha == null)
                {
                    Nodo<T> nuevoNodo = new Nodo<T>();
                    nuevoNodo.Valor = valor;
                    nuevoNodo.Llave = nuevaLlave;
                    tmp.Derecha = nuevoNodo;
                }
                else
                {
                    Agregar(valor, nuevaLlave, tmp.Derecha);
                }
            }
        }

        public List<InfoIndice> Buscar(string valor)
        {
            List<InfoIndice> infoIndices = new List<InfoIndice>();
            //TODO: recorer arbol y evaluar valor
            return infoIndices;
        }
    }
}
