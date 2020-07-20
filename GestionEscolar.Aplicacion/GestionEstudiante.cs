using System;
using System.Collections.Generic;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEscolar.Datos.Interfaces;
using GestionEstudiantes.Modelos;
using GestionEstudiantes.Modelos.DTO;

namespace GestionEscolar.Aplicacion
{
    public class GestionEstudiante : IGestionEstudiante
    {
        private readonly IGestionEscolarContexto _contexto;

        public GestionEstudiante(IGestionEscolarContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return _contexto.ObtenerEstudiantes();
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            _contexto.AgregarEstudiante(estudiante);
            _contexto.GuardarCambios();
        }

        public void ModificarNotasEstudiante(CalificacionesEstudiante calificacionesEstudiante)
        {
            _contexto.ModificarNotasEstudiante(calificacionesEstudiante.tarjetaIdentidad, calificacionesEstudiante.idGrupo,
                calificacionesEstudiante.calificacionPrimerPeriodo, calificacionesEstudiante.calificacionSegundoPeriodo,
                calificacionesEstudiante.calificacionTercerPeriodo);
            _contexto.GuardarCambios();
        }

        public void EliminarEstudiante(string tarjetaIdentidad)
        {
            Estudiante estudianteAEliminar = _contexto.ObtenerEstudiante(tarjetaIdentidad);
            _contexto.EliminarEstudiante(estudianteAEliminar);
            _contexto.GuardarCambios();
        }

        public void ModificarNombreEstudiante(Estudiante estudiante)
        {
            _contexto.ModificarNombreEstudiante(estudiante.TarjetaIdentidad, estudiante);
            _contexto.GuardarCambios();
        }

        public void AsignarMateria(MateriaEstudiante materia)
        {
            _contexto.AsignarMateriaAEstudiante(materia);
            _contexto.GuardarCambios();
        }

        public void EliminarMateria(MateriaEstudiante materia)
        {
            _contexto.EliminarMateriaDeEstudiante(materia);
            _contexto.GuardarCambios();
        }

        public List<Grupo> ObtenerGrupos()
        {
            return _contexto.ObtenerGrupos();
        }
    }
}
