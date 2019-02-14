using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class EstudianteFileRepository : IEstudianteRepository
    {
        List<EstudianteViewModel> listaEstudiantes = new List<EstudianteViewModel>();

        public EstudianteFileRepository()
        {
            //System.IO.StreamReader lector = new System.IO.StreamReader(@"C:\Users\wcast\Desktop\Estudiantes.json");
            string texto = System.IO.File.ReadAllText(@"C:\Users\wcast\Desktop\Estudiantes.json");
            listaEstudiantes= JsonConvert.DeserializeObject<List<EstudianteViewModel>>(texto);
            //while (!lector.EndOfStream)
            //{
            //    string linea =lector.ReadLine();
            //    if (!string.IsNullOrEmpty(linea))
            //    {
            //        EstudianteViewModel estudiante = JsonConvert.DeserializeObject<EstudianteViewModel>(linea);
            //        listaEstudiantes.Add(estudiante);
            //    }
            //}
            //lector.Close();
        }

        public EstudianteViewModel ObtenerEstudiante(int id)
        {
            EstudianteViewModel estudiante =
                listaEstudiantes.FirstOrDefault(x => x.Id == id);
            return estudiante;
        }

        public List<EstudianteViewModel> ObtenerEstudiantes()
        {
            return listaEstudiantes;
        }

        public void CrearEstudiante(EstudianteViewModel nuevoEstudiante)
        {
            listaEstudiantes.Add(nuevoEstudiante);
           
            try
            {
                string texto = JsonConvert.SerializeObject(listaEstudiantes);
                System.IO.File.WriteAllText(@"C:\Users\wcast\Desktop\Estudiantes.json", texto);
            //    System.IO.StreamWriter escritor = new System.IO.StreamWriter(@"C:\Users\wcast\Desktop\Estudiantes.json", true);
            //    string linea = JsonConvert.SerializeObject(nuevoEstudiante);
            //    escritor.WriteLine(linea);
            //    escritor.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
           
        }

        public void ModificarEstudiante(EstudianteViewModel nuevo)
        {
            for (int i = 0; i < listaEstudiantes.Count; i++)
            {
                if (listaEstudiantes[i].Id == nuevo.Id)
                {
                    listaEstudiantes[i].Nombre = nuevo.Nombre;
                    listaEstudiantes[i].Apellido = nuevo.Apellido;
                }
            }
            try
            {
                string texto = JsonConvert.SerializeObject(listaEstudiantes);
                System.IO.File.WriteAllText(@"C:\Users\wcast\Desktop\Estudiantes.json", texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
            //listaEstudiantes.RemoveAt(listaEstudiantes.FindIndex(x => x.Id == nuevo.Id));
            //listaEstudiantes.Add(nuevo);
        }

        public void QuitarEstudiante(int id)
        {
            listaEstudiantes.RemoveAt(listaEstudiantes.FindIndex(x => x.Id == id));
            try
            {
                string texto = JsonConvert.SerializeObject(listaEstudiantes);
                System.IO.File.WriteAllText(@"C:\Users\wcast\Desktop\Estudiantes.json", texto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}
