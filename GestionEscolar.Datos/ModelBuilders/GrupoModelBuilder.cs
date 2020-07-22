using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEscolar.Datos.ModelBuilders
{
    public class GrupoModelBuilder : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupos");
            builder.HasKey(entidad => entidad.Id);
            builder.HasIndex(entidad => new
            {
                entidad.CedulaProfesor,
                entidad.IdMateria
            })
                .IsUnique();
            builder.Property(entidad => entidad.CedulaProfesor).HasColumnType("VARCHAR(50)").IsRequired();
            builder.HasOne(entidad => entidad.Profesor)
                .WithMany(entidad => entidad.Grupos)
                .HasForeignKey(entidad => entidad.CedulaProfesor);
            builder.HasOne(entidad => entidad.Materia)
                .WithMany(entidad => entidad.Grupos)
                .HasForeignKey(entidad => entidad.IdMateria);
        }
    }
}
