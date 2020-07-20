using System;
using System.Collections.Generic;
using System.Linq;
using Fenix.Excepciones;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using GTHFenixNugets.TestFramework.Extensiones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEstudiantes.Tests.Servicios
{
    [TestClass]
    public class EstudianteServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
        }

        [TestMethod]
        public void Debe_ObtenerEstudiantes()
        {
            List<Estudiante> estudiantesEsperados = new List<Estudiante>()
            {
                new Estudiante("1007465364", "Antonio José Díaz Valbuena"),
                new Estudiante("1076622840", "Luis Felipe Díaz Valbuena")
            };

            List<Estudiante> estudiantesActuales = _contexto.ObtenerEstudiantes();

            Assert.That.AreCollectionsEqual(estudiantesEsperados, estudiantesActuales, entidad => entidad.Materias);
        }

        [TestMethod]
        public void Debe_ObtenerEstudiante()
        {
            Estudiante estudianteEsperado = new Estudiante("1076622840", "Luis Felipe Díaz Valbuena");

            Estudiante estudianteActual = _contexto.ObtenerEstudiante("1076622840");

            Assert.That.ArePropertiesEqual(estudianteEsperado, estudianteActual, estudiante => estudiante.Materias);
        }

        [TestMethod]
        public void Debe_ObtenerEstudiante_SiEstudianteNoExiste_ArrojarError()
        {
            var mensajeEsperado = "No existe este estudiante";

            var mensajeActual = Assert.ThrowsException<Exception>(() =>
                    _contexto.ObtenerEstudiante("2039847"),
                mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_AgregarEstudiante()
        {
            List<Estudiante> estudiantesEsperados = new List<Estudiante>()
            {
                new Estudiante("1007465364", "Antonio José Díaz Valbuena"),
                new Estudiante("1023803452", "Carlos Eduardo Díaz Valbuena"),
                new Estudiante("1076622840", "Luis Felipe Díaz Valbuena")
            };

            _contexto.AgregarEstudiante(new Estudiante("1023803452", "Carlos Eduardo Díaz Valbuena"));
            _contexto.GuardarCambios();

            List<Estudiante> estudiantesActuales = _contexto.ObtenerEstudiantes();

            Assert.That.AreCollectionsEqual(estudiantesEsperados, estudiantesActuales, estudiante => estudiante.Materias);
        }

        [TestMethod]
        public void Debe_AgregarEstudiante_SiEstudianteExiste_ArrojarError()
        {
            var mensajeEsperado = "Ya existe este estudiante";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                _contexto.AgregarEstudiante(new Estudiante("1076622840", "Luis Felipe Díaz Valbuena")),
                mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_ModificarNotasEstudiante()
        {
            Estudiante estudianteEsperado = new Estudiante("1007465364", "Antonio José Díaz Valbuena");
            MateriaEstudiante materiaEsperada = new MateriaEstudiante(1, "1007465364");
            materiaEsperada.ModificarNotas(1.2f, 1.2f, 1.2f);
            estudianteEsperado.Materias.Add(materiaEsperada);

            _contexto.ModificarNotasEstudiante("1007465364", 1, 1.2f, 1.2f, 1.2f);
            _contexto.GuardarCambios();

            Estudiante estudianteActual = _contexto.ObtenerEstudiante("1007465364");

            MateriaEstudiante materiaActual = estudianteActual.Materias.First();

            Assert.AreEqual(materiaEsperada.CalificacionPrimerPeriodo, materiaActual.CalificacionPrimerPeriodo);
            Assert.AreEqual(materiaEsperada.CalificacionSegundoPeriodo, materiaActual.CalificacionSegundoPeriodo);
            Assert.AreEqual(materiaEsperada.CalificacionTercerPeriodo, materiaActual.CalificacionTercerPeriodo);
        }

        [TestMethod]
        public void Debe_ModificarNotasEstudiante_SiMateriaNoCoincide_ArrojaError()
        {
            var mensajeEsperado = "El estudiante no tiene inscrita la materia";

            var mensajeActual = Assert.ThrowsException<FenixExceptionNotFound>(() =>
                    _contexto.ModificarNotasEstudiante("1007465364", 5, 1.2f, 1.2f, 1.2f),
                mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_EliminarEstudiante()
        {
            Estudiante estudianteAEliminar = _contexto.ObtenerEstudiante("1007465364");

            List<Estudiante> estudiantesEsperados = new List<Estudiante>()
            {
                new Estudiante("1076622840", "Luis Felipe Díaz Valbuena")
            };

            _contexto.EliminarEstudiante(estudianteAEliminar);
            _contexto.GuardarCambios();

            List<Estudiante> estudiantesActuales = _contexto.ObtenerEstudiantes();

            Assert.That.AreCollectionsEqual(estudiantesEsperados, estudiantesActuales,
                estudiante => estudiante.Materias);
        }

        [TestMethod]
        public void Debe_ModificarNombreEstudiante()
        {
            Estudiante estudianteEsperado = new Estudiante("1007465364", "Antonio");

            _contexto.ModificarNombreEstudiante("1007465364", estudianteEsperado);
            _contexto.GuardarCambios();

            Estudiante estudianteActual = _contexto.ObtenerEstudiante("1007465364");

            Assert.That.ArePropertiesEqual(estudianteEsperado, estudianteActual, estudiante => estudiante.Materias);
        }
    }
}