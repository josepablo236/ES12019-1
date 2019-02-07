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
                // TODO: Add insert logic here
                CursoEntity nuevoCurso = (CursoEntity)curso;
                //nuevoCurso.Id = curso.Id;
                //nuevoCurso.CodCatedratico = curso.CodCatedratico;
                nuevoCurso.Materia = materiaRepository.ObtenerMaterias().FirstOrDefault(x => x.Id == materia);
                nuevoCurso.Estudiantes = new List<EstudianteViewModel>();
                cursoRepository.CrearCurso(nuevoCurso);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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