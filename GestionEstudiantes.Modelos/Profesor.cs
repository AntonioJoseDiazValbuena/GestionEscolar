using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos
{
    public class Profesor
    {
        public int Id { get; }
        public string Cedula { get; private set; }
        public string Nombre { get; private set; }
        public ICollection<Grupo> Grupos { get; private set; }

        public Profesor(string cedula, string nombre)
        {
            Cedula = cedula;
            Nombre = nombre;
            Grupos = new List<Grupo>();
        }

        public void ModificarNombre(string nombre)
        {
            Nombre = nombre;
        }

        private Profesor()
        {
        }
    }
}
