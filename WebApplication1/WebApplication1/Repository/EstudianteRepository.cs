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

        public EstudianteRepository()
        {
            listaEstudiantes.Add(new EstudianteViewModel()
            {
                Id = 1,
                Nombre = "Willy",
                Apellido = "Castillo"
            });
            EstudianteViewModel est2 = new EstudianteViewModel()
            {
                Id = 2,
                Nombre = "Miriam",
                Apellido = "Castillo"
            };
            listaEstudiantes.Add(est2);
            EstudianteViewModel est3 = new EstudianteViewModel();
            est3.Id = 3;
            est3.Nombre = "Juan";
            est3.Apellido = "Lopez";
            listaEstudiantes.Add(est3);
        }

        public EstudianteViewModel ObtenerEstudiante(int id)
        {
            EstudianteViewModel estudiante =
                listaEstudiantes.FirstOrDefault(x => x.Id == id);
            return estudiante;
        }

        public List<EstudianteViewModel> ObtenerEstudiantes()
        {
            return listaEstudiantes;
        }

        public void CrearEstudiante(EstudianteViewModel nuevoEstudiante)
        {
            listaEstudiantes.Add(nuevoEstudiante);
        }
    }
}
