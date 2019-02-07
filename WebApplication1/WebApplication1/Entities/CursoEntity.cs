using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Entities
{
    public class CursoEntity
    {
        public int Id { get; set; }
        public string CodCatedratico { get; set; }
        public MateriaViewModel Materia { get; set; }
        public List<EstudianteViewModel> Estudiantes { get; set; }
    }
}
