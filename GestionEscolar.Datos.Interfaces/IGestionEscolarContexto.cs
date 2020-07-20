using System.Collections.Generic;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Datos.Interfaces
{
    public interface IGestionEscolarContexto
    {
        List<Estudiante> ObtenerEstudiantes();
        Estudiante ObtenerEstudiante(string tarjetaIdentidad);
        void AgregarEstudiante(Estudiante estudiante);
        void ModificarNotasEstudiante(string tarjetaIdentidad, int idGrupo, float? calificacionPrimerPeriodo,
            float? calificacionSegundoPeriodo, float? calificacionTercerPeriodo);
        void EliminarEstudiante(Estudiante estudiante);
        void ModificarNombreEstudiante(string tarjetaIdentidad, Estudiante estudiante);

        void AsignarMateriaAEstudiante(MateriaEstudiante materia);
        void EliminarMateriaDeEstudiante(MateriaEstudiante materia);

        List<Profesor> ObtenerProfesores();
        Profesor ObtenerProfesor(string cedula);
        void AgregarProfesor(Profesor profesor);
        void ModificarNombreProfesor(string cedula, Profesor profesor);
        void EliminarProfesor(Profesor profesor);

        List<Grupo> ObtenerGrupos();
        Grupo ObtenerGrupo(int id);
        void AsignarMateriaAProfesor(Grupo grupo);
        void EliminarGrupo(Grupo grupo);
        bool EstudianteAsginadoAGrupo(int idGrupo);

        List<Materia> ObtenerMaterias();
        Materia ObtenerMateria(int id);
        void AgregarMateria(Materia materia);
        void EliminarMateria(Materia materia);
        bool MateriaTieneEstudiantes(int id);

        void GuardarCambios();
    }
}
