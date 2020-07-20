using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos.DTO
{
    public class CalificacionesEstudiante
    {
        public string tarjetaIdentidad { get; private set; }
        public int idGrupo { get; private set; }
        public float? calificacionPrimerPeriodo { get; private set; }
        public float? calificacionSegundoPeriodo { get; private set; }
        public float? calificacionTercerPeriodo { get; private set; }

        public CalificacionesEstudiante(string tarjetaIdentidad, int idGrupo, float? calificacionPrimerPeriodo, float? calificacionSegundoPeriodo, float? calificacionTercerPeriodo)
        {
            this.tarjetaIdentidad = tarjetaIdentidad;
            this.idGrupo = idGrupo;
            this.calificacionPrimerPeriodo = calificacionPrimerPeriodo;
            this.calificacionSegundoPeriodo = calificacionSegundoPeriodo;
            this.calificacionTercerPeriodo = calificacionTercerPeriodo;
        }
    }
}
