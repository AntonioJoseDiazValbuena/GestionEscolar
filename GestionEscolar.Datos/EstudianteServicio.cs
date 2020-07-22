using System;
using System.Collections.Generic;
using System.Linq;
using Fenix.Excepciones;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;

namespace GestionEscolar.Datos
{
    public partial class GestionEscolarContexto
    {
        public List<Estudiante> ObtenerEstudiantes()
        {
            return Estudiantes
                .Include(entidad => entidad.Materias)
                .ThenInclude(entidad => entidad.Grupo)
                .ThenInclude(entidad => entidad.Profesor)
                .Include(entidad => entidad.Materias)
                .ThenInclude(entidad => entidad.Grupo)
                .ThenInclude(entidad => entidad.Materia)
                .OrderBy(entidad => entidad.Nombre).ToList();
        }

        public Estudiante ObtenerEstudiante(string tarjetaIdentidad)
        {
            Estudiante estudianteActual =
                Estudiantes
                    .Include(entidad => entidad.Materias)
                    .ThenInclude(entidad => entidad.Grupo)
                    .ThenInclude(entidad => entidad.Profesor)
                    .Include(entidad => entidad.Materias)
                    .ThenInclude(entidad => entidad.Grupo)
                    .ThenInclude(entidad => entidad.Materia)
                    .FirstOrDefault(entidad => entidad.TarjetaIdentidad == tarjetaIdentidad);

            if (estudianteActual is null)
                throw new Exception("No existe este estudiante");

            return estudianteActual;
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            if (Estudiantes.Any(entidad => entidad.TarjetaIdentidad == estudiante.TarjetaIdentidad))
                throw new FenixExceptionConflict("Ya existe este estudiante");

            Estudiantes.Add(estudiante);
        }

        public void ModificarNotasEstudiante(string tarjetaIdentidad, int idGrupo, float? calificacionPrimerPeriodo,
            float? calificacionSegundoPeriodo, float? calificacionTercerPeriodo)
        {
            Estudiante estudianteActual = ObtenerEstudiante(tarjetaIdentidad);
            MateriaEstudiante materiaActual = estudianteActual.Materias.FirstOrDefault(entidad => entidad.IdGrupo == idGrupo);

            if (materiaActual is null)
                throw new FenixExceptionNotFound("El estudiante no tiene inscrita la materia");

            materiaActual.ModificarNotas(calificacionPrimerPeriodo, calificacionSegundoPeriodo,
                calificacionTercerPeriodo);
        }

        public void EliminarEstudiante(Estudiante estudiante)
        {
            Estudiantes.Remove(estudiante);
        }

        public void ModificarNombreEstudiante(string tarjetaIdentidad, Estudiante estudiante)
        {
            Estudiante estudianteActual = ObtenerEstudiante(tarjetaIdentidad);

            estudianteActual.ModificarNombre(estudiante.Nombre);
        }
    }
}
