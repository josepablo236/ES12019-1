using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class EstudianteRepository : IEstudianteRepository
    {
        List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();

        public List<EstudianteViewModel> ObtenerEstudiantes()
        {
            return listaEstudiantes;
        }
    }
}
