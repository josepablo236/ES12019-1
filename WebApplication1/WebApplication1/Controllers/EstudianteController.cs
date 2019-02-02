using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class EstudianteController : Controller
    {
        readonly IEstudianteRepository estudianteRepository;
        public EstudianteController(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        // GET: Estudiante
        public ActionResult Index()
        {
            List<EstudianteViewModel> listaEstudiantes= estudianteRepository.ObtenerEstudiantes();
            return View(listaEstudiantes);
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            EstudianteViewModel estudiante = estudianteRepository.ObtenerEstudiante(id);
            return View(estudiante);
        }

        // GET: Estudiante/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]EstudianteViewModel estudiante)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // TODO: Add insert logic here
                    estudianteRepository.CrearEstudiante(estudiante);
                    return RedirectToAction(nameof(Index));
                }
                else {
                    return View(estudiante);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            EstudianteViewModel estudiante = estudianteRepository.ObtenerEstudiante(id);
            return View(estudiante);
        }

        // POST: Estudiante/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm]EstudianteViewModel estudiante)
        {
            try
            {
                estudianteRepository.ModificarEstudiante(estudiante);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            EstudianteViewModel estudiante = estudianteRepository.ObtenerEstudiante(id);
            return View(estudiante);
        }

        // POST: Estudiante/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] EstudianteViewModel estudiante)
        {
            try
            {
                // TODO: Add delete logic here
                estudianteRepository.QuitarEstudiante(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}