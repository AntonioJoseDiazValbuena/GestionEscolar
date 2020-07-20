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
    public class GrupoServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
        }

        [TestMethod]
        public void Debe_ObtenerGrupos()
        {
            List<Grupo> gruposEsperados = new List<Grupo>()
            {
                new Grupo("1076622840", 1),
                new Grupo("1076621880", 1),
                new Grupo("1076621880", 2)
            };

            List<Grupo> gruposActuales = _contexto.ObtenerGrupos();

            Assert.That.AreCollectionsEqual(gruposEsperados, gruposActuales,
                grupo => grupo.Profesor,
                grupo => grupo.Materia,
                grupo => grupo.MateriasEstudiantes,
                grupo => grupo.Id);
        }

        [TestMethod]
        public void Debe_ObtenerGrupo()
        {
            Grupo grupoEsperado = new Grupo("1076621880", 1);

            Grupo grupoActual = _contexto.ObtenerGrupo(2);

            Assert.That.ArePropertiesEqual(grupoEsperado, grupoActual,
                grupo => grupo.Profesor,
                grupo => grupo.Materia,
                grupo => grupo.MateriasEstudiantes,
                grupo => grupo.Id);
        }

        [TestMethod]
        public void Debe_ObtenerGrupo_SiGrupoNoExiste_ArrojarError()
        {
            var mensajeEsperado = "No hay profesores que dicten esta materia";

            var mensajeActual = Assert.ThrowsException<FenixExceptionNotFound>(() =>
                _contexto.ObtenerGrupo(5), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }

        [TestMethod]
        public void Debe_AsignarMateriaAProfesor()
        {
            Grupo grupoAAgregar = new Grupo("1076622840", 2);

            List<Grupo> gruposEsperados = new List<Grupo>()
            {
                new Grupo("1076622840", 1),
                new Grupo("1076621880", 1),
                new Grupo("1076621880", 2),
                new Grupo("1076622840", 2)
            };

            _contexto.AsignarMateriaAProfesor(grupoAAgregar);
            _contexto.GuardarCambios();

            List<Grupo> gruposActuales = _contexto.ObtenerGrupos();

            Assert.That.AreCollectionsEqual(gruposEsperados, gruposActuales,
                grupo => grupo.Profesor,
                grupo => grupo.Materia,
                grupo => grupo.MateriasEstudiantes,
                grupo => grupo.Id);
        }

        [TestMethod]
        public void Debe_EliminarGrupo()
        {
            Grupo grupoAEliminar = _contexto.ObtenerGrupo(2);

            List<Grupo> gruposEsperados = new List<Grupo>()
            {
                new Grupo("1076622840", 1),
                new Grupo("1076621880", 2)
            };

            _contexto.EliminarGrupo(grupoAEliminar);
            _contexto.GuardarCambios();

            List<Grupo> gruposActuales = _contexto.ObtenerGrupos();

            Assert.That.AreCollectionsEqual(gruposEsperados, gruposActuales,
                grupo => grupo.Profesor,
                grupo => grupo.Materia,
                grupo => grupo.MateriasEstudiantes,
                grupo => grupo.Id);
        }

        [TestMethod]
        public void Debe_EstudianteAsignadoAGrupo_SiNoHayEstudiantesEnGrupo_RetornarFalse()
        {
            Assert.IsFalse(_contexto.EstudianteAsginadoAGrupo(3));
        }

        [TestMethod]
        public void Debe_EstudianteAsignadoAGrupo_SiHayEstudianteEnGrupo_RetornarTrue()
        {
            Assert.IsTrue(_contexto.EstudianteAsginadoAGrupo(1));
        }
    }
}
