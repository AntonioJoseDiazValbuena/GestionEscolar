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
        public List<Materia> ObtenerMaterias()
        {
            return Materias
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.MateriasEstudiantes)
                .ThenInclude(entidad => entidad.Estudiante)
                .OrderBy(entidad => entidad.Nombre).ToList();
        }

        public Materia ObtenerMateria(int id)
        {
            Materia materiaActual = Materias
                .Include(entidad => entidad.Grupos)
                .ThenInclude(entidad => entidad.MateriasEstudiantes)
                .ThenInclude(entidad => entidad.Estudiante)
                .FirstOrDefault(entidad => entidad.Id == id);

            if (materiaActual is null)
                throw new FenixExceptionNotFound("Esta materia no existe");

            return materiaActual;
        }

        public void AgregarMateria(Materia materia)
        {
            if (Materias.Any(entidad => entidad.Nombre.ToLower() == materia.Nombre.ToLower()))
                throw new FenixExceptionConflict("Esta materia ya se encuentra registrada");

            Materias.Add(materia);
        }

        public void EliminarMateria(Materia materia)
        {
            Materias.Remove(materia);
        }

        public bool MateriaTieneEstudiantes(int id)
        {
            return Grupos.Any(entidad => entidad.IdMateria == id && entidad.MateriasEstudiantes.Any());
        }
    }
}
