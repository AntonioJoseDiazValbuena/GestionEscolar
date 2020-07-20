using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEstudiantes.Modelos
{
    public class Grupo
    {
        public int Id { get; private set; }
        public string CedulaProfesor { get; set; }
        public int IdMateria { get; set; }
        public ICollection<MateriaEstudiante> MateriasEstudiantes { get; private set; }
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }

        public Grupo(string cedulaProfesor, int idMateria)
        {
            CedulaProfesor = cedulaProfesor;
            IdMateria = idMateria;
            MateriasEstudiantes = new List<MateriaEstudiante>();
        }
    }
}
