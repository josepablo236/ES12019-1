using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IEstudianteRepository
    {
        List<EstudianteViewModel> ObtenerEstudiantes();
        EstudianteViewModel ObtenerEstudiante(int id);
        void CrearEstudiante(EstudianteViewModel nuevoEstudiante);
        void ModificarEstudiante(EstudianteViewModel nuevo);
        void QuitarEstudiante(int id);
    }
}
