using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Aplicacion.Interfaces
{
    public interface IGestionMateria
    {
        List<Materia> ObtenerMaterias();
        void AgregarMateria(Materia materia);
        void EliminarMateria(int id);
    }
}
