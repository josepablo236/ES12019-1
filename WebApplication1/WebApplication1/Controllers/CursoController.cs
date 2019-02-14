using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class CursoController : Controller
    {
        ICursoRepository cursoRepository;
        IEstudianteRepository estudianteRepository;
        IMateriaRepository materiaRepository;
        public CursoController(ICursoRepository cursoRepository,
            IEstudianteRepository estudianteRepository,
            IMateriaRepository materiaRepository)
        {
            this.cursoRepository = cursoRepository;
            this.estudianteRepository = estudianteRepository;
            this.materiaRepository = materiaRepository;
        }
        // GET: Curso
        public ActionResult Index()
        {
            List<CursoEntity> cursos = cursoRepository.ObtenerCursos();
            return View(cursos);
        }

        // GET: Curso/Details/5
        public ActionResult Details(int id)
        {
            CursoViewModel curso = new CursoViewModel();
            CursoEntity cursoE=cursoRepository.ObtenerCursos().FirstOrDefault(x => x.Id == id);
            curso.EstudiantesDisponibles = estudianteRepository.ObtenerEstudiantes();
            curso.MateriasDisponibles = materiaRepository.ObtenerMaterias();
            curso.Id = cursoE.Id;
            curso.CodCatedratico = cursoE.CodCatedratico;
            curso.Materia = cursoE.Materia;
            curso.MateriaSeleccionada = cursoE.Materia.Id.ToString();
            curso.Estudiantes = cursoE.Estudiantes;
            return View(curso);
        }

        // GET: Curso/Create
        public ActionResult Create()
        {
            CursoViewModel curso = new CursoViewModel();
            curso.EstudiantesDisponibles = estudianteRepository.ObtenerEstudiantes();
            curso.MateriasDisponibles = materiaRepository.ObtenerMaterias();
            return View(curso);
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]CursoViewModel curso)
        {
            try
            {
                int materia = Convert.ToInt32(curso.MateriaSeleccionada);
                int estudiante = Convert.ToInt32(curso.EstudianteSeleccionado);
                // TODO: Add insert logic here
                CursoEntity nuevoCurso = (CursoEntity)curso;
                //nuevoCurso.Id = curso.Id;
                //nuevoCurso.CodCatedratico = curso.CodCatedratico;
                nuevoCurso.Materia = materiaRepository.ObtenerMaterias().FirstOrDefault(x => x.Id == materia);
                nuevoCurso.Estudiantes = new List<EstudianteViewModel>();
                nuevoCurso.Estudiantes.Add(estudianteRepository.ObtenerEstudiante(estudiante));
                cursoRepository.CrearCurso(nuevoCurso);

                return RedirectToAction("Edit", new { id = nuevoCurso.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {

            CursoEntity curso = cursoRepository.ObtenerCurso(id);
            CursoViewModel cursovm = new CursoViewModel()
            {
                Id = curso.Id,
                Materia = curso.Materia,
                CodCatedratico = curso.CodCatedratico,
                Estudiantes = curso.Estudiantes
            };
            cursovm.MateriaSeleccionada = curso.Materia.Id.ToString();
            cursovm.EstudiantesDisponibles = estudianteRepository.ObtenerEstudiantes();
            cursovm.MateriasDisponibles = materiaRepository.ObtenerMaterias();
            return View(cursovm);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarEstudiante(int id, IFormCollection collection)
        {
            try
            {
                CursoEntity curso = cursoRepository.ObtenerCurso(id);

                int estudiante = Convert.ToInt32(collection["EstudianteSeleccionado"]);
                
                curso.Estudiantes.Add(estudianteRepository.ObtenerEstudiantes().FirstOrDefault(x => x.Id == estudiante));
                cursoRepository.ModificarCurso(curso);
                return RedirectToAction("Edit", new { id = id });
            }
            catch
            {
                return RedirectToAction("Edit", new { id = id });
            }
        }

        public ActionResult QuitarEstudiante(int id, int idEstudiante)
        {
            try
            {
                CursoEntity curso = cursoRepository.ObtenerCurso(id);

                curso.Estudiantes.RemoveAt(curso.Estudiantes.FindIndex(x => x.Id == idEstudiante));

                cursoRepository.ModificarCurso(curso);
                return RedirectToAction("Edit", new { id = id });
            }
            catch
            {
                return RedirectToAction("Edit", new { id = id });
            }
        }
        // GET: Curso/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Curso/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}