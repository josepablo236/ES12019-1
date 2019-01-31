using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EstudianteViewModel
    {
        [Required(ErrorMessage = "El id del estudiante es requerido")]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del estudiante es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del estudiante es requerido")]
        public string Apellido { get; set; }
    }
}
