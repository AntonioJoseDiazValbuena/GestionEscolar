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
    }
}
