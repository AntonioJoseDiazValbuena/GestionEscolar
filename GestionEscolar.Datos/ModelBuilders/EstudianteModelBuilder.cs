using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEscolar.Datos.ModelBuilders
{
    public class EstudianteModelBuilder : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.ToTable("Estudiantes");
            builder.HasKey(entidad => entidad.TarjetaIdentidad);
            builder.Property(entidad => entidad.TarjetaIdentidad).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(entidad => entidad.Nombre).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasMany(entidad => entidad.Materias)
                .WithOne(entidad => entidad.Estudiante)
                .HasForeignKey(entidad => entidad.TarjetaIdentidadEstudiante);
        }
    }
}
