using System;
using System.Linq;
using Fenix.Excepciones;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Datos
{
    public partial class GestionEscolarContexto
    {
        public void AsignarMateriaAEstudiante(MateriaEstudiante materia)
        {
            MateriasEstudiantes.Add(materia);
        }

        public void EliminarMateriaDeEstudiante(MateriaEstudiante materia)
        {
            Estudiante estudianteActual = ObtenerEstudiante(materia.TarjetaIdentidadEstudiante);
            MateriaEstudiante materiaActual = estudianteActual.Materias.FirstOrDefault(entidad => entidad.IdGrupo == materia.IdGrupo);

            if (materiaActual is null)
                throw new FenixExceptionNotFound("El estudiante no tiene inscrita la materia");

            MateriasEstudiantes.Remove(materiaActual);
        }
    }
}
