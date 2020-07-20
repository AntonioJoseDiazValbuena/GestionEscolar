using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos
{
    public class Materia
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public ICollection<Grupo> Grupos { get; private set; }

        public Materia(string nombre)
        {
            Nombre = nombre;
            Grupos = new List<Grupo>();
        }
    }
}
