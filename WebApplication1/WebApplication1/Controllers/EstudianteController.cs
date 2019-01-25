using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EstudianteController : Controller
    {
        List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();
        
        public EstudianteController()
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

        // GET: Estudiante
        public ActionResult Index()
        {


            listaEstudiantes.Add(new EstudianteViewModel()
            {
                Id = 4,
                Nombre = "Willy",
                Apellido = "Castillo"
            });

            return View(listaEstudiantes);
        }

        // GET: Estudiante/Details/5
        public ActionResult Details(int id)
        {
            EstudianteViewModel estudiante =
                listaEstudiantes.FirstOrDefault(x => x.Id == id);
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
        //public ActionResult Create([FromForm]EstudianteViewModel estudiante)
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiante/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiante/Edit/5
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

        // GET: Estudiante/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiante/Delete/5
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