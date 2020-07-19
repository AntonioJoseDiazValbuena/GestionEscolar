using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEscolar.Datos.ModelBuilders
{
    public class MateriaModelBuilder : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materias");
            builder.HasKey(entidad => entidad.Id);
            builder.Property(entidad => entidad.Nombre).HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
        }
    }
}
