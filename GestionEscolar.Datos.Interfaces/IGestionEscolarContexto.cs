using System;
using System.Collections.Generic;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Datos.Interfaces
{
    public interface IGestionEscolarContexto
    {
        List<Estudiante> ObtenerEstudiantes();
    }
}
