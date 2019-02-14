using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public class CursoViewModel: CursoEntity
    {
        public List<MateriaViewModel> MateriasDisponibles { get; set; }
        public List<EstudianteViewModel> EstudiantesDisponibles { get; set; }
        public string MateriaSeleccionada { get; set; }
        public string EstudianteSeleccionado { get; set; }
    }
}
