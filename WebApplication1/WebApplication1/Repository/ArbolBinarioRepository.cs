using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ArbolBinarioUtils;
using WebApplication1.Entities;

namespace WebApplication1.Repository
{
    public class ArbolBinarioRepository
    {
        string path = @"C:\Users\wcast\git_lab05\ES12019\MOCK_DATA.csv";
        ArbolBinario<InfoIndice> arbolBinario;

        public ArbolBinarioRepository()
        {
            arbolBinario = new ArbolBinario<InfoIndice>();
        }

        public void LoadFile()
        {
            
            System.IO.StreamReader lector = new System.IO.StreamReader(path);
            while (!lector.EndOfStream)
            {
                string linea = lector.ReadLine();
                string[] valores = linea.Split(",");
                //numero de linea valores[0]
                //llave nombre [1]
                //cantidad[5]

                InfoIndice nuevoIndice = new InfoIndice();
                nuevoIndice.Linea = Convert.ToInt32(valores[0]);
                nuevoIndice.Nombre = valores[1];
                nuevoIndice.Existencia = Convert.ToInt32(valores[5]);
                arbolBinario.Agregar(nuevoIndice, nuevoIndice.Nombre);
            }
            lector.Close();
        }

        public FarmacoEntity ObtenerFarmaco(int linea)
        {
            FarmacoEntity farmaco = new FarmacoEntity();
            string line = File.ReadLines(path).Skip(linea+1).Take(1).First();
            //TODO: Leer farmaco de archivo
            return farmaco;

        }

        public List<FarmacoEntity> BuscarFarmacos(string valor, int numeroDePagina, int noElementos)
        {
            List<InfoIndice> listaIndices = arbolBinario.Buscar(valor).Skip(numeroDePagina -1 *noElementos).Take(noElementos).ToList();
            List<FarmacoEntity> farmacoEntities = new List<FarmacoEntity>();
            foreach (var item in listaIndices)
            {
                farmacoEntities.Add(ObtenerFarmaco(item.Linea));
            }
            return farmacoEntities;
        }
    }
}
