using System.Collections.Generic;
using Fenix.Excepciones;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEscolar.Datos.Interfaces;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Aplicacion
{
    public class GestionMateria : IGestionMateria
    {
        private readonly IGestionEscolarContexto _contexto;

        public GestionMateria(IGestionEscolarContexto contexto)
        {
            _contexto = contexto;
        }

        public List<Materia> ObtenerMaterias()
        {
            return _contexto.ObtenerMaterias();
        }

        public void AgregarMateria(Materia materia)
        {
            _contexto.AgregarMateria(materia);
            _contexto.GuardarCambios();
        }

        public void EliminarMateria(int id)
        {
            Materia materiaAEliminar = _contexto.ObtenerMateria(id);

            foreach (Grupo grupo in materiaAEliminar.Grupos)
            {
                if (_contexto.MateriaTieneEstudiantes(grupo.Id))
                    throw new FenixExceptionConflict("No se puede eliminar la materia porque tiene estudiantes inscritos");
            }

            _contexto.EliminarMateria(materiaAEliminar);
            _contexto.GuardarCambios();
        }
    }
}
