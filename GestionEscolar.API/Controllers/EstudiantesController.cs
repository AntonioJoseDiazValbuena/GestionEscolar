using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly GestionEscolarContexto _contexto;

        public EstudiantesController(GestionEscolarContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public ActionResult<Estudiante> ObtenerEstudiantes()
        {
            return _contexto.Estudiantes.First();
        }
    }
}