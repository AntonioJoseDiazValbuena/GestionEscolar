using System;
using System.Collections.Generic;
using GestionEstudiantes.Modelos;
using GestionEstudiantes.Modelos.DTO;

namespace GestionEscolar.Aplicacion.Interfaces
{
    public interface IGestionEstudiante
    {
        List<Estudiante> ObtenerEstudiantes();
        void AgregarEstudiante(Estudiante estudiante);
        void ModificarNotasEstudiante(CalificacionesEstudiante calificacionesEstudiante);
        void EliminarEstudiante(string tarjetaIdentidad);
        void ModificarNombreEstudiante(Estudiante estudiante);
        void AsignarMateria(MateriaEstudiante materia);
        void EliminarMateria(MateriaEstudiante materia);
        List<Grupo> ObtenerGrupos();
    }
}
