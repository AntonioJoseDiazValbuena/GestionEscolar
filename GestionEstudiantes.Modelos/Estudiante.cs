using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos
{
    public class Estudiante
    {
        public int Id { get; }
        public string TarjetaIdentidad { get; private set; }
        public string Nombre { get; private set; }
        public ICollection<MateriaEstudiante> Materias { get; private set; }

        public Estudiante(string tarjetaIdentidad, string nombre)
        {
            TarjetaIdentidad = tarjetaIdentidad;
            Nombre = nombre;
        }
    }
}
