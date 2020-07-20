using System.Collections.Generic;
using Fenix.Excepciones;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEscolar.Datos.Interfaces;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Aplicacion
{
    public class GestionProfesor : IGestionProfesor
    {
        private readonly IGestionEscolarContexto _contexto;

        public GestionProfesor(IGestionEscolarContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Profesor> ObtenerProfesores()
        {
            return _contexto.ObtenerProfesores();
        }

        public void AgregarProfesor(Profesor profesor)
        {
            _contexto.AgregarProfesor(profesor);
            _contexto.GuardarCambios();
        }

        public void ModificarNombreProfesor(Profesor profesor)
        {
            _contexto.ModificarNombreProfesor(profesor.Cedula, profesor);
            _contexto.GuardarCambios();
        }

        public void EliminarProfesor(string cedula)
        {
            Profesor profesorAEliminar = _contexto.ObtenerProfesor(cedula);

            foreach (Grupo grupo in profesorAEliminar.Grupos)
            {
                if (_contexto.MateriaTieneEstudiantes(grupo.IdMateria))
                    throw new FenixExceptionConflict(
                        "No puede eliminar al profesor porque dicta una o más materias con estudiantes inscritos");
            }

            _contexto.EliminarProfesor(profesorAEliminar);
            _contexto.GuardarCambios();

        }

        public void AsignarMateriaAProfesor(Grupo grupo)
        {
            _contexto.AsignarMateriaAProfesor(grupo);
            _contexto.GuardarCambios();
        }

        public void EliminarGrupo(int idGrupo)
        {
            Grupo grupo = _contexto.ObtenerGrupo(idGrupo);

            if (_contexto.MateriaTieneEstudiantes(grupo.IdMateria))
                throw new FenixExceptionConflict(
                    "No puede eliminarle la materia al profesor porque hay estudiantes inscritos");

            _contexto.EliminarGrupo(grupo);
            _contexto.GuardarCambios();
        }
    }
}
