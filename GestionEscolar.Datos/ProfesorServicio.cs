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
        public List<Profesor> ObtenerProfesores()
        {
            return Profesores
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.Materia)
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.MateriasEstudiantes)
                .ThenInclude(entidad => entidad.Estudiante)
                .OrderBy(entidad => entidad.Nombre).ToList();
        }

        public Profesor ObtenerProfesor(string cedula)
        {
            Profesor profesorActual = Profesores
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.Materia)
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.MateriasEstudiantes)
                .ThenInclude(entidad => entidad.Estudiante)
                .FirstOrDefault(entidad => entidad.Cedula == cedula);

            if (profesorActual is null)
                throw new FenixExceptionNotFound("Este profesor no se encuentra registrado en la institución");

            return profesorActual;
        }

        public void AgregarProfesor(Profesor profesor)
        {
            if (Profesores.Any(entidad => entidad.Cedula == profesor.Cedula))
                throw new FenixExceptionConflict("Ya existe este profesor");

            Profesores.Add(profesor);
        }

        public void ModificarNombreProfesor(string cedula, Profesor profesor)
        {
            Profesor profesorActual = ObtenerProfesor(cedula);

            profesorActual.ModificarNombre(profesor.Nombre);
        }

        public void EliminarProfesor(Profesor profesor)
        {
            Profesores.Remove(profesor);
        }
    }
}
