using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MateriaRepository : IMateriaRepository
    {
        List<MateriaViewModel> listaMaterias = new List<MateriaViewModel>();

        public MateriaRepository()
        {
            listaMaterias.Add(new MateriaViewModel()
            {
                Id = 1,
                Nombre = "Introduccion a la Programacion"
            });
            listaMaterias.Add(new MateriaViewModel()
            {
                Id = 2,
                Nombre = "Programacion Avanzada"
            });
            listaMaterias.Add(new MateriaViewModel()
            {
                Id = 3,
                Nombre = "Estructuras de Datos I"
            });
        }

        public MateriaViewModel ObtenerMateria(int id)
        {
            MateriaViewModel estudiante =
                listaMaterias.FirstOrDefault(x => x.Id == id);
            return estudiante;
        }

        public List<MateriaViewModel> ObtenerMaterias()
        {
            return listaMaterias;
        }

        public void CrearMateria(MateriaViewModel nuevoMateria)
        {
            listaMaterias.Add(nuevoMateria);
        }

        public void ModificarMateria(MateriaViewModel nuevo)
        {
            for (int i = 0; i < listaMaterias.Count; i++)
            {
                if (listaMaterias[i].Id == nuevo.Id)
                {
                    listaMaterias[i].Nombre = nuevo.Nombre;
                }
            }

            //listaMaterias.RemoveAt(listaMaterias.FindIndex(x => x.Id == nuevo.Id));
            //listaMaterias.Add(nuevo);
        }

        public void QuitarMateria(int id)
        {
            listaMaterias.RemoveAt(listaMaterias.FindIndex(x => x.Id == id));

        }
    }
}
