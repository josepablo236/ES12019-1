using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public class TablaRepository : ITablaRepository
    {
        string basePath = @"C:\Users\wcastillos\Desktop\MyMicroSQL";
        public List<DefTabla> ObtenerTablas()
        {
            //leer basePath y
            return new List<DefTabla>();
        }

        public void CrearTabla(string nombreTabla, List<DefColumna> columnas)
        {
            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(basePath + @"\" + nombreTabla.ToUpper() + ".tabla"))
            {
                streamWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(columnas));
                streamWriter.Close();
            }
        }
    }
}
