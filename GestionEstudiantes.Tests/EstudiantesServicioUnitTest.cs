using System.Collections.Generic;
using System.Linq;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GestionEstudiantes.Tests
{
    [TestClass]
    public class EstudiantesServicioUnitTest
    {
        private GestionEscolarContexto _contexto;

        [TestInitialize]
        public void Inicializacion()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<GestionEscolarContexto>(config => config.UseInMemoryDatabase("GestionEscolar"));
            ServiceProvider sp = serviceCollection.BuildServiceProvider();
            _contexto = sp.GetService<GestionEscolarContexto>();

            List<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante("1007465364", "Antonio Jos� D�az Valbuena"),
                new Estudiante("1076622840", "Luis Felipe D�az Valbuena")
            };

            _contexto.Estudiantes.Add(new Estudiante("", ""));
            _contexto.SaveChanges();
        }

        [TestMethod]
        public void Debe_ObtenerEstudiantes()
        {
            List<Estudiante> estudiantesEsperados = new List<Estudiante>()
            {
                new Estudiante("1007465364", "Antonio Jos� D�az Valbuena"),
                new Estudiante("1076622840", "Luis Felipe D�az Valbuena")
            };

            List<Estudiante> estudiantesActuales = _contexto.ObtenerEstudiantes();

            Assert.AreEqual(estudiantesEsperados, _contexto.Estudiantes.ToList().Count);
        }
    }
}