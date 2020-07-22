using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos.DTO
{
    public class CalificacionesEstudiante
    {
        public int IdGrupo { get; private set; }
        public string TarjetaIdentidad { get; private set; }
        public float? CalificacionPrimerPeriodo { get; private set; }
        public float? CalificacionSegundoPeriodo { get; private set; }
        public float? CalificacionTercerPeriodo { get; private set; }

        public CalificacionesEstudiante(int idGrupo, string tarjetaIdentidadEstudiante, float? calificacionPrimerPeriodo, float? calificacionSegundoPeriodo, float? calificacionTercerPeriodo)
        {
            IdGrupo = idGrupo;
            TarjetaIdentidad = tarjetaIdentidadEstudiante;
            CalificacionPrimerPeriodo = calificacionPrimerPeriodo;
            CalificacionSegundoPeriodo = calificacionSegundoPeriodo;
            CalificacionTercerPeriodo = calificacionTercerPeriodo;
        }
    }
}
