using System.Collections.Generic;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEstudiantes.Modelos;
using GestionEstudiantes.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IGestionEstudiante _gestionEstudiante;

        public EstudiantesController(IGestionEstudiante gestionEstudiante)
        {
            _gestionEstudiante = gestionEstudiante;
        }

        [HttpGet]
        public List<Estudiante> ObtenerEstudiantes()
        {
            return _gestionEstudiante.ObtenerEstudiantes();
        }

        [HttpGet]
        [Route("Materias")]
        public List<Grupo> ObtenerMaterias()
        {
            return _gestionEstudiante.ObtenerGrupos();
        }

        [HttpPost]
        public void AgregarEstudiante(Estudiante estudiante)
        {
            _gestionEstudiante.AgregarEstudiante(estudiante);
        }

        [HttpPut]
        [Route("Materias/Calificaciones")]
        public void ModificarNotasEstudiante(CalificacionesEstudiante calificacionesEstudiante)
        {
            _gestionEstudiante.ModificarNotasEstudiante(calificacionesEstudiante);
        }

        [HttpPut]
        [Route("Materias")]
        public void AsignarMateria(MateriaEstudiante materia)
        {
            _gestionEstudiante.AsignarMateria(materia);
        }

        [HttpPut]
        [Route("Materias/Remover")]
        public void EliminarMateria(MateriaEstudiante materia)
        {
            _gestionEstudiante.EliminarMateria(materia);
        }

        [HttpPut]
        public void ModificarNombreEstudiante(Estudiante estudiante)
        {
            _gestionEstudiante.ModificarNombreEstudiante(estudiante);
        }

        [HttpDelete]
        [Route("{tarjetaIdentificacion}")]
        public void EliminarEstudiante(string tarjetaIdentificacion)
        {
            _gestionEstudiante.EliminarEstudiante(tarjetaIdentificacion);
        }
    }
}