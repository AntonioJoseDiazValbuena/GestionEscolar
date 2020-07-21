using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;

namespace GestionEscolar.Aplicacion.Interfaces
{
    public interface IGestionProfesor
    {
        List<Profesor> ObtenerProfesores();
        void AgregarProfesor(Profesor profesor);
        void ModificarNombreProfesor(Profesor profesor);
        void EliminarProfesor(string cedula);
        void AsignarMateriaAProfesor(Grupo grupo);
        void EliminarGrupo(Grupo grupo);
    }
}
