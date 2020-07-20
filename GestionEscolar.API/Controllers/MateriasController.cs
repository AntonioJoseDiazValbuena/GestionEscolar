using System.Collections.Generic;
using GestionEscolar.Aplicacion.Interfaces;
using GestionEstudiantes.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IGestionMateria _gestionMateria;

        public MateriasController(IGestionMateria gestionMateria)
        {
            _gestionMateria = gestionMateria;
        }

        [HttpGet]
        public List<Materia> ObtenerMaterias()
        {
            return _gestionMateria.ObtenerMaterias();
        }

        [HttpPost]
        public void AgregarMateria(Materia materia)
        {
            _gestionMateria.AgregarMateria(materia);
        }

        [HttpDelete]
        [Route("{id}")]
        public void EliminarMateria(int id)
        {
            _gestionMateria.EliminarMateria(id);
        }
    }
}