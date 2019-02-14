using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface IMateriaRepository
    {
        List<MateriaViewModel> ObtenerMaterias();
        MateriaViewModel ObtenerMateria(int id);
        void CrearMateria(MateriaViewModel nuevaMateria);
        void ModificarMateria(MateriaViewModel nuevo);
        void QuitarMateria(int id);
    }
}
