using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos
{
    public class Estudiante
    {
        private Estudiante()
        {
        }

        public int Id { get; }
        public string TarjetaIdentidad { get; private set; }
        public string Nombre { get; private set; }
        public ICollection<MateriaEstudiante> Materias { get; set; }

        public Estudiante(string tarjetaIdentidad, string nombre)
        {
            TarjetaIdentidad = tarjetaIdentidad;
            Nombre = nombre;
            Materias = new List<MateriaEstudiante>();
        }

        public void ModificarNombre(string nombre)
        {
            Nombre = nombre;
        }
    }
}
