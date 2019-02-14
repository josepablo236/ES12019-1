using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CursoRepository : ICursoRepository
    {
        List<CursoEntity> listaCursos = new List<CursoEntity>();

        public CursoRepository()
        {
            CursoEntity curso = new CursoEntity();
            curso.Id = 1;
            curso.CodCatedratico = "CAT26751";
            curso.Materia = new MateriaViewModel()
            {
                Id = 1,
                Nombre = "Introduccion a la Programacion"
            };
            curso.Estudiantes = new List<EstudianteViewModel>();
            curso.Estudiantes.Add(new EstudianteViewModel()
            {
                Id = 1,
                Nombre = "Willy",
                Apellido = "Castillo"
            });
            curso.Estudiantes.Add(new EstudianteViewModel()
            {
                Id = 2,
                Nombre = "Miriam",
                Apellido = "Castillo"
            });
            listaCursos.Add(curso);
        }

        public CursoEntity ObtenerCurso(int id)
        {
            CursoEntity estudiante =
                listaCursos.FirstOrDefault(x => x.Id == id);
            return estudiante;
        }

        public List<CursoEntity> ObtenerCursos()
        {
            return listaCursos;
        }

        public void CrearCurso(CursoEntity nuevoCurso)
        {
            listaCursos.Add(nuevoCurso);
        }

        public void ModificarCurso(CursoEntity nuevo)
        {
            for (int i = 0; i < listaCursos.Count; i++)
            {
                if (listaCursos[i].Id == nuevo.Id)
                {
                    //TODO: implementar actualizacion de los campos
                }
            }

            //listaCursos.RemoveAt(listaCursos.FindIndex(x => x.Id == nuevo.Id));
            //listaCursos.Add(nuevo);
        }

        public void QuitarCurso(int id)
        {
            listaCursos.RemoveAt(listaCursos.FindIndex(x => x.Id == id));

        }
    }

}
