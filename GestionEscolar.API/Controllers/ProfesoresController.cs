using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEstudiantes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly IGestionProfesor _gestionProfesor;

        public ProfesoresController(IGestionProfesor gestionProfesor)
        {
            _gestionProfesor = gestionProfesor;
        }

        [HttpGet]
        public List<Profesor> ObtenerProfesores()
        {
            return _gestionProfesor.ObtenerProfesores();
        }

        [HttpPost]
        public void AgregarProfesor(Profesor profesor)
        {
            _gestionProfesor.AgregarProfesor(profesor);
        }

        [HttpPut]
        public void ModificarNombreProfesor(Profesor profesor)
        {
            _gestionProfesor.ModificarNombreProfesor(profesor);
        }

        [HttpDelete]
        [Route("{cedula}")]
        public void EliminarProfesor(string cedula)
        {
            _gestionProfesor.EliminarProfesor(cedula);
        }

        [HttpPut]
        [Route("Materias")]
        public void AsignarMateriaAProfesor(Grupo grupo)
        {
            _gestionProfesor.AsignarMateriaAProfesor(grupo);
        }

        [HttpPut]
        [Route("Materias/Remover")]
        public void EliminarGrupo(Grupo grupo)
        {
            _gestionProfesor.EliminarGrupo(grupo);
        }
    }
}