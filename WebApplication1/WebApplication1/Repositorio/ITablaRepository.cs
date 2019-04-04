using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositorio
{
    public interface ITablaRepository
    {
        List<DefTabla> ObtenerTablas();
        void CrearTabla(string nombreTabla, List<DefColumna> columnas);
    }
}
