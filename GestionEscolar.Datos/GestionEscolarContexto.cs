using System;
using System.Collections.Generic;
using System.Text;
using GestionEscolar.Datos.Interfaces;
using GestionEscolar.Datos.ModelBuilders;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionEscolar.Datos
{
    public partial class GestionEscolarContexto : DbContext, IGestionEscolarContexto
    {
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<MateriaEstudiante> MateriasEstudiantes { get; set; }
        public DbSet<Profesor> Profesores { get; set; }

        public GestionEscolarContexto(DbContextOptions<GestionEscolarContexto> contexto) : base(contexto)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstudianteModelBuilder());
            modelBuilder.ApplyConfiguration(new GrupoModelBuilder());
            modelBuilder.ApplyConfiguration(new MateriaEstudianteModelBuilder());
            modelBuilder.ApplyConfiguration(new MateriaModelBuilder());
            modelBuilder.ApplyConfiguration(new ProfesorModelBuilder());

            base.OnModelCreating(modelBuilder);
        }
    }
}
