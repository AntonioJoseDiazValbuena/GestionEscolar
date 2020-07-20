using Fenix.Excepciones;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEstudiantes.Tests.Servicios
{
    [TestClass]
    public class MateriaEstudianteServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            _contexto = InicializacionContextoPrueba.InicializarContexto();
        }

        [TestMethod]
        public void Debe_AsignarMateriaAEstudiante()
        {
            MateriaEstudiante materiaAAgregar = new MateriaEstudiante(3, "1007465364");

            Estudiante estudianteEsperado = new Estudiante("1007465364", "Antonio José Díaz Valbuena");
            estudianteEsperado.Materias.Add(new MateriaEstudiante(1, "1007465364"));
            estudianteEsperado.Materias.Add(new MateriaEstudiante(2, "1007465364"));
            estudianteEsperado.Materias.Add(new MateriaEstudiante(3, "1007465364"));

            _contexto.AsignarMateriaAEstudiante(materiaAAgregar);
            _contexto.GuardarCambios();

            Estudiante estudianteActual = _contexto.ObtenerEstudiante("1007465364");

            Assert.AreEqual(estudianteEsperado.Materias.Count, estudianteActual.Materias.Count);
            Assert.AreEqual(estudianteEsperado.TarjetaIdentidad, estudianteActual.TarjetaIdentidad);
        }

        [TestMethod]
        public void Debe_EliminarMateriaDeEstudiante()
        {
            MateriaEstudiante materiaAEliminar = new MateriaEstudiante(1, "1007465364");

            Estudiante estudianteEsperado = new Estudiante("1007465364", "Antonio José Díaz Valbuena");
            estudianteEsperado.Materias.Add(new MateriaEstudiante(2, "1007465364"));

            _contexto.EliminarMateriaDeEstudiante(materiaAEliminar);
            _contexto.GuardarCambios();

            Estudiante estudianteActual = _contexto.ObtenerEstudiante("1007465364");

            Assert.AreEqual(estudianteEsperado.Materias.Count, estudianteActual.Materias.Count);
            Assert.AreEqual(estudianteEsperado.TarjetaIdentidad, estudianteActual.TarjetaIdentidad);
        }

        [TestMethod]
        public void Debe_EliminarMateriaDeEstudiante_SiMateriaNoExiste_ArrojarError()
        {
            var mensajeEsperado = "El estudiante no tiene inscrita la materia";

            var mensajeActual = Assert.ThrowsException<FenixExceptionNotFound>(() =>
                _contexto.EliminarMateriaDeEstudiante(new MateriaEstudiante(5, "1007465364")), mensajeEsperado);

            Assert.AreEqual(mensajeEsperado, mensajeActual.Message);
        }
    }
}
