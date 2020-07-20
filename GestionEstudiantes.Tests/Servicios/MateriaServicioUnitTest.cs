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
    public class MateriaServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
        }

        [TestMethod]
        public void Debe_ObtenerMaterias()
        {
            List<Materia> materiasEsperadas = new List<Materia>()
            {
                new Materia("Ciencias"),
                new Materia("Matematicas")
            };

            List<Materia> materiasActuales = _contexto.ObtenerMaterias();

            Assert.That.AreCollectionsEqual(materiasEsperadas, materiasActuales, materia => materia.Grupos,
                materia => materia.Id);
        }

        [TestMethod]
        public void Debe_ObtenerMateria()
        {
            Materia materiaEsperada = new Materia("Matematicas");

            Materia materiaActual = _contexto.ObtenerMateria(2);

            Assert.That.ArePropertiesEqual(materiaEsperada, materiaActual, materia => materia.Grupos,
                materia => materia.Id);
        }

        [TestMethod]
        public void Debe_ObtenerMateria_SiMateriaNoExiste_ArrojarError()
        {
            var mensajeEsperado = "Esta materia no existe";

            var mensajeActual = Assert.ThrowsException<FenixExceptionNotFound>(() =>
                _contexto.ObtenerMateria(6), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_AgregarMateria()
        {
            Materia materiaAAgregar = new Materia("Geología");

            List<Materia> materiasEsperadas = new List<Materia>()
            {
                new Materia("Ciencias"),
                new Materia("Geología"),
                new Materia("Matematicas")
            };

            _contexto.AgregarMateria(materiaAAgregar);
            _contexto.GuardarCambios();

            List<Materia> materiasActuales = _contexto.ObtenerMaterias();

            Assert.That.AreCollectionsEqual(materiasEsperadas, materiasActuales, materia => materia.Grupos,
                materia => materia.Id);
        }

        [TestMethod]
        public void Debe_AgregarMateria_SiMateriaYaExiste_ArrojarError()
        {
            var mensajeEsperado = "Esta materia ya se encuentra registrada";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                _contexto.AgregarMateria(new Materia("Ciencias")), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_EliminarMateria()
        {
            Materia materiaAEliminar = _contexto.ObtenerMateria(2);

            List<Materia> materiasEsperadas = new List<Materia>()
            {
                new Materia("Ciencias")
            };

            _contexto.EliminarMateria(materiaAEliminar);
            _contexto.GuardarCambios();

            List<Materia> materiasActuales = _contexto.ObtenerMaterias();

            Assert.That.AreCollectionsEqual(materiasEsperadas, materiasActuales, materia => materia.Grupos,
                materia => materia.Id);
        }

        [TestMethod]
        public void Debe_MateriaTieneEstudiantes_RetornarFalse_SiMateriaNoEstaAsignadaAUnEstudiante()
        {
            Assert.IsFalse(_contexto.MateriaTieneEstudiantes(2));
        }

        [TestMethod]
        public void Debe_MateriaTieneEstudiantes_RetornarTrue_SiMateriaEstaAsignadaAUnEstudiante()
        {
            Assert.IsTrue(_contexto.MateriaTieneEstudiantes(1));
        }
    }
}
