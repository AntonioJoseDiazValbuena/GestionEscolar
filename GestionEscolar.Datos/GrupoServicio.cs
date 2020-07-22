using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fenix.Excepciones;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Datos
{
    public partial class GestionEscolarContexto
    {
        public List<Grupo> ObtenerGrupos()
        {
            return Grupos.Include(entidad => entidad.Profesor)
                .Include(entidad => entidad.Materia)
                .Include(entidad => entidad.MateriasEstudiantes)
                .OrderBy(entidad => entidad.Materia.Nombre).ToList();
        }

        public Grupo ObtenerGrupo(int id)
        {
            Grupo grupoActual = Grupos.FirstOrDefault(entidad => entidad.Id == id);

            if (grupoActual is null)
                throw new FenixExceptionNotFound("No hay profesores que dicten esta materia");

            return grupoActual;
        }

        public void AsignarMateriaAProfesor(Grupo grupo)
        {
            Grupos.Add(grupo);
        }

        public void EliminarGrupo(Grupo grupo)
        {
            Grupos.Remove(grupo);
        }

        public bool EstudianteAsginadoAGrupo(int idGrupo)
        {
            return Grupos.Any(entidad => entidad.Id == idGrupo && entidad.MateriasEstudiantes.Any());
        }
    }
}
