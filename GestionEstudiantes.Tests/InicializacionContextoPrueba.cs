using System;
using System.Collections.Generic;
using System.Text;
using GestionEscolar.Datos;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GestionEstudiantes.Tests
{
    public class InicializacionContextoPrueba
    {
        public static GestionEscolarContexto InicializarContexto()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<GestionEscolarContexto>(config => config.UseInMemoryDatabase("GestionEscolar"));
            ServiceProvider sp = serviceCollection.BuildServiceProvider();

            List<Estudiante> estudiantes = new List<Estudiante>()
            {
                new Estudiante("1007465364", "Antonio José Díaz Valbuena"),
                new Estudiante("1076622840", "Luis Felipe Díaz Valbuena")
            };

            List<Profesor> profesores = new List<Profesor>()
            {
                new Profesor("1076622840", "Luis Felipe Díaz Valbuena"),
                new Profesor("1076621880", "Carlos Eduardo Díaz Valbuena")
            };

            List<Materia> materias = new List<Materia>()
            {
                new Materia("Ciencias"),
                new Materia("Matematicas")
            };

            List<Grupo> grupos = new List<Grupo>()
            {
                new Grupo("1076622840", 1)
                {
                    Materia = materias[0],
                    Profesor = profesores[0]
                },
                new Grupo("1076621880", 1)
                {
                    Materia = materias[0],
                    Profesor = profesores[1]
                },
                new Grupo("1076621880", 2)
                {
                    Materia = materias[1],
                    Profesor = profesores[1]
                }
            };

            List<MateriaEstudiante> materiasEstudiantes = new List<MateriaEstudiante>()
            {
                new MateriaEstudiante(1, "1007465364")
                {
                    Grupo = grupos[0],
                    Estudiante = estudiantes[0]
                },
                new MateriaEstudiante(2, "1007465364")
                {
                    Grupo = grupos[1],
                    Estudiante = estudiantes[0]
                }
            };

            var _contexto = sp.GetService<GestionEscolarContexto>();
            _contexto.Database.EnsureDeleted();
            _contexto.Database.EnsureCreated();
            _contexto.Grupos.AddRange(grupos);
            _contexto.MateriasEstudiantes.AddRange(materiasEstudiantes);
            _contexto.Profesores.AddRange(profesores);
            _contexto.Materias.AddRange(materias);
            _contexto.Estudiantes.AddRange(estudiantes);
            _contexto.GuardarCambios();

            return _contexto;
        }
    }
}