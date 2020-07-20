using System;
using System.Collections.Generic;
using Fenix.Excepciones;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using GTHFenixNugets.TestFramework.Extensiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEstudiantes.Tests.Servicios
{
    [TestClass]
    public class ProfesorServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
        }

        [TestMethod]
        public void Debe_ObtenerProfesores()
        {
            List<Profesor> profesoresEsperados = new List<Profesor>()
            {
                new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena"),
                new Profesor("1076622840", "Luis Felipe Díaz Valbuena")
            };

            List<Profesor> profesoresActuales = _contexto.ObtenerProfesores();

            Assert.That.AreCollectionsEqual(profesoresEsperados, profesoresActuales, profesor => profesor.Grupos);
        }

        [TestMethod]
        public void Debe_ObtenerProfesor()
        {
            Profesor profesorEsperado = new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena");

            Profesor profesorActual = _contexto.ObtenerProfesor("1076621880");

            Assert.That.ArePropertiesEqual(profesorEsperado, profesorActual, profesor => profesor.Grupos);
        }

        [TestMethod]
        public void Debe_ObtenerProfesor_SiProfesorNoExiste_ArrojarError()
        {
            var mensajeEsperado = "Este profesor no se encuentra registrado en la institución";

            var mensajeActual = Assert.ThrowsException<FenixExceptionNotFound>(() =>
                _contexto.ObtenerProfesor("20983620"), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_AgregarProfesor()
        {
            List<Profesor> profesoresEsperados = new List<Profesor>()
            {
                new Profesor("1007465364", "Antonio José Díaz Valbuena"),
                new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena"),
                new Profesor("1076622840", "Luis Felipe Díaz Valbuena")
            };

            _contexto.AgregarProfesor(new Profesor("1007465364", "Antonio José Díaz Valbuena"));
            _contexto.GuardarCambios();

            List<Profesor> profesoresActuales = _contexto.ObtenerProfesores();

            Assert.That.AreCollectionsEqual(profesoresEsperados, profesoresActuales, profesor => profesor.Grupos);
        }

        [TestMethod]
        public void Debe_AgregarProfesor_SiProfesorExiste_ArrojarError()
        {
            var mensajeEsperado = "Ya existe este profesor";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                    _contexto.AgregarProfesor(new Profesor("1076622840", "Luis Felipe Díaz Valbuena")),
                mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_ModificarNombreProfesor()
        {
            Profesor profesorEsperado = new Profesor("1076622840", "Antonio");

            _contexto.ModificarNombreProfesor("1076622840", profesorEsperado);
            _contexto.GuardarCambios();

            Profesor profesorActual = _contexto.ObtenerProfesor("1076622840");

            Assert.That.ArePropertiesEqual(profesorEsperado, profesorActual, estudiante => estudiante.Grupos);
        }

        [TestMethod]
        public void Debe_EliminarProfesor()
        {
            Profesor profesorAEliminar = _contexto.ObtenerProfesor("1076622840");

            List<Profesor> profesoresEsperados = new List<Profesor>()
            {
                new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena")
            };

            _contexto.EliminarProfesor(profesorAEliminar);
            _contexto.GuardarCambios();

            List<Profesor> profesoresActuales = _contexto.ObtenerProfesores();

            Assert.That.AreCollectionsEqual(profesoresEsperados, profesoresActuales, profesor => profesor.Grupos);
        }
    }
}
