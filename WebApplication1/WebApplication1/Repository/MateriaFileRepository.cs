using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class MateriaFileRepository : IMateriaRepository
    {
        public void CrearMateria(MateriaViewModel nuevaMateria)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                file.WriteLine(nuevaMateria.ToString());
            }

        }

        public void ModificarMateria(MateriaViewModel nuevo)
        {
            throw new NotImplementedException();
        }

        public MateriaViewModel ObtenerMateria(int id)
        {
            throw new NotImplementedException();
        }

        public List<MateriaViewModel> ObtenerMaterias()
        {
            throw new NotImplementedException();
        }

        public void QuitarMateria(int id)
        {
            throw new NotImplementedException();
        }
    }
}
