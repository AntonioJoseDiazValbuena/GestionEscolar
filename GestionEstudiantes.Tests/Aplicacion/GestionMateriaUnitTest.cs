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
    public class GestionMateriaUnitTest
    {
        private GestionEscolarContexto _contexto;
        private GestionMateria _gestionMateria;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
            _gestionMateria = new GestionMateria(_contexto);
        }

        [TestMethod]
        public void Debe_EliminarMateria()
        {
            List<Materia> materiasEsperadas = new List<Materia>()
            {
                new Materia("Ciencias")
            };

            _gestionMateria.EliminarMateria(2);

            List<Materia> materiasActuales = _contexto.ObtenerMaterias();

            Assert.That.AreCollectionsEqual(materiasEsperadas, materiasActuales, materia => materia.Grupos,
                materia => materia.Id);
        }

        [TestMethod]
        public void Debe_EliminarMateria_SiHayEstudiantesIngresadosEnLaMateria_ArrojarError()
        {
            var mensajeEsperado = "No se puede eliminar la materia porque tiene estudiantes inscritos";

            var mensajeActual = Assert.ThrowsException<FenixExceptionConflict>(() =>
                _gestionMateria.EliminarMateria(1), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }
    }
}
