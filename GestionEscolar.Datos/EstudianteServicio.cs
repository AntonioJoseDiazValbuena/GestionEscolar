using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Datos
{
    public partial class GestionEscolarContexto
    {
        public List<Estudiante> ObtenerEstudiantes()
        {
            return Estudiantes.OrderBy(entidad => entidad.Nombre).ToList();
        }
    }
}
