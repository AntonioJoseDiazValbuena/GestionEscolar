using System;
using System.Collections.Generic;
using System.Text;
using Fenix.Excepciones;
using GestionEscolar.Aplicacion;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using GTHFenixNugets.TestFramework.Extensiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEstudiantes.Tests.Aplicacion
{
    [TestClass]
    public class GestionProfesorUnitTest
    {
        private GestionEscolarContexto _contexto;
        private GestionProfesor _gestionProfesor;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
            _gestionProfesor = new GestionProfesor(_contexto);
        }

        [TestMethod]
        public void Debe_EliminarProfesor()
        {
            Profesor nuevoProfesor = new Profesor("10076622840", "Antonio");

            _gestionProfesor.AgregarProfesor(nuevoProfesor);

            List<Profesor> profesoresEsperados = new List<Profesor>()
            {
                new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena"),
                new Profesor("1076622840", "Luis Felipe Díaz Valbuena")
            };

            _gestionProfesor.EliminarProfesor("10076622840");

            List<Profesor> profesoresActuales = _contexto.ObtenerProfesores();

            Assert.That.AreCollectionsEqual(profesoresEsperados, profesoresActuales, profesor => profesor.Grupos);
        }

        [TestMethod]
        public void Debe_EliminarProfesor_SiGrupoTieneEstudiantesRegistrados_ArrojarError()
        {
            var mensajeEsperado =
                "No puede eliminar al profesor porque dicta una o más materias con estudiantes inscritos";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                _gestionProfesor.EliminarProfesor("1076622840"), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_EliminarGrupo()
        {
            List<Grupo> gruposEsperados = new List<Grupo>()
            {
                new Grupo("1076622840", 1),
                new Grupo("1076621880", 1)
            };

            _gestionProfesor.EliminarGrupo(3);

            List<Grupo> gruposActuales = _contexto.ObtenerGrupos();

            Assert.That.AreCollectionsEqual(gruposEsperados, gruposActuales,
                grupo => grupo.Profesor,
                grupo => grupo.Materia,
                grupo => grupo.MateriasEstudiantes,
                grupo => grupo.Id);
        }

        [TestMethod]
        public void Debe_EliminarGrupo_SiMateriaTieneEstudiantesInscritos_ArrojarError()
        {
            var mensajeEsperado =
                "No puede eliminarle la materia al profesor porque hay estudiantes inscritos";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                _gestionProfesor.EliminarGrupo(2), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }
    }
}
