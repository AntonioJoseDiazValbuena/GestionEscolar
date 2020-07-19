using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEscolar.Datos.ModelBuilders
{
    public class ProfesorModelBuilder : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {
            builder.ToTable("Profesores");
            builder.HasKey(entidad => entidad.Cedula);
            builder.Property(entidad => entidad.Cedula).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(entidad => entidad.Nombre).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasMany(entidad => entidad.Grupos)
                .WithOne(entidad => entidad.Profesor)
                .HasForeignKey(entidad => entidad.CedulaProfesor);
        }
    }
}
