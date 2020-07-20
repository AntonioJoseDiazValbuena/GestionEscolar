using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos.DTO
{
    public class CalificacionesEstudiante
    {
        public string TarjetaIdentidad { get; private set; }
        public int IdGrupo { get; private set; }
        public float? CalificacionPrimerPeriodo { get; private set; }
        public float? CalificacionSegundoPeriodo { get; private set; }
        public float? CalificacionTercerPeriodo { get; private set; }

        public CalificacionesEstudiante(string tarjetaIdentidad, int idGrupo, float? calificacionPrimerPeriodo, float? calificacionSegundoPeriodo, float? calificacionTercerPeriodo)
        {
            TarjetaIdentidad = tarjetaIdentidad;
            IdGrupo = idGrupo;
            CalificacionPrimerPeriodo = calificacionPrimerPeriodo;
            CalificacionSegundoPeriodo = calificacionSegundoPeriodo;
            CalificacionTercerPeriodo = calificacionTercerPeriodo;
        }
    }
}
