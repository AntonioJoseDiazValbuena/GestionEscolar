using System;
using System.Collections.Generic;
using System.Text;
using GestionEstudiantes.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEscolar.Datos.ModelBuilders
{
    public class MateriaEstudianteModelBuilder : IEntityTypeConfiguration<MateriaEstudiante>
    {
        public void Configure(EntityTypeBuilder<MateriaEstudiante> builder)
        {
            builder.ToTable("MateriasEstudiantes");
            builder.HasKey("IdGrupo", "TarjetaIdentidadEstudiante");
            builder.Property(entidad => entidad.TarjetaIdentidadEstudiante).HasColumnType("VARCHAR(50)").HasMaxLength(50);
            builder.HasOne(entidad => entidad.Estudiante)
                .WithMany(entidad => entidad.Materias)
                .HasForeignKey(entidad => entidad.TarjetaIdentidadEstudiante);
            builder.HasOne(entidad => entidad.Grupo)
                .WithMany(entidad => entidad.MateriasEstudiantes)
                .HasForeignKey(entidad => entidad.IdGrupo);
        }
    }
}
