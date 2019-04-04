using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositorio;

namespace WebApplication1.Controllers
{
    public class ComandoController : Controller
    {
        ITablaRepository _tablaRepository;
        public ComandoController(ITablaRepository tablaRepository)
        {
            _tablaRepository = tablaRepository;
        }
        
        // GET: Comando
        public ActionResult Index()
        {

            return View();
        }

        // GET: Comando/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public string EjecutarComando(string Comando)
        {
            string[] palabras = Comando.Split(" ");
            int estado = 0;
            string nombreTabla="";
            string tipoComando="";
            List<DefColumna> listaDefColumnas = new List<DefColumna>() ;
            DefColumna tmp = new DefColumna();
            string resultado = "";
            foreach (var palabra in palabras)
            {
                switch (estado)
                {
                    case 0:
                        if (palabra.ToUpper() == "CREATE")
                        {
                            estado = 1;
                        }
                        else if(palabra.ToUpper()=="SELECT")
                        {
                            estado = 8;
                        }
                        else if (palabra.ToUpper() == "INSERT")
                        {
                            
                        }
                        break;
                    case 1:
                        if (palabra.ToUpper() == "TABLE")
                        {
                            tipoComando = "CREAR_TABLA";
                            estado = 2;
                        }
                        break;
                    case 2:
                        nombreTabla = palabra;
                        estado = 3;
                        break;
                    case 3:
                        if (palabra == "(")
                        {
                            estado = 4;
                        }
                        break;
                    case 4:
                        tmp = new DefColumna();
                        tmp.nombreColumna = palabra;
                        estado = 5;
                        break;
                    case 5:
                        tmp.tipoColumna = palabra;
                        listaDefColumnas.Add(tmp);
                        estado = 6;
                        break;
                    case 6:
                        if (palabra == ",")
                        {
                            estado = 4;
                        }
                        else if (palabra == ")")
                        {
                            estado =7;
                        }
                        break;
                    case 7:
                        if (palabra.ToUpper() == "GO")
                        {

                            if(tipoComando == "CREAR_TABLA")
                            {
                                //termine y creo el archivo y el arbol, devolver tabla creada correctamente
                                _tablaRepository.CrearTabla(nombreTabla, listaDefColumnas);
                                resultado = "Tabla creada exitosamente";
                            }
                            else if(tipoComando == "SELECCIONAR_VALORES")
                            {
                                //ir a traer datos
                            }
                        }
                        break;
                    case 8:
                        if(palabra.ToUpper() == "FROM")
                        {
                            estado = 9;
                        }
                        break;
                    case 9:
                        nombreTabla = palabra;
                        tipoComando = "SELECCIONAR_VALORES";
                        estado = 7;
                        break;
                    default:
                        break;
                }
            }
            return resultado;
        }

        
        // GET: Comando/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comando/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Comando comando)
        {
            try
            {
                // TODO: Add insert logic here
                //identificar el tipo de comando
                //Create
                comando.Resultado=EjecutarComando(comando.TextoComando);                
                return View();
            }
            catch
            {
                comando.Resultado = "Error al crear la tabla, contacte a su administrador";                
                return View();
            }
        }

        // GET: Comando/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comando/Edit/5
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

        // GET: Comando/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comando/Delete/5
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