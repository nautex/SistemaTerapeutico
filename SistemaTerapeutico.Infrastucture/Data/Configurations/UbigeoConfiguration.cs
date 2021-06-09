using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.HasKey(e => e.IdUbigeo)
                    .HasName("PRIMARY");

            builder.ToTable("ubigeo");

            builder.Property(e => e.IdUbigeo).HasColumnType("int(11)");

            builder.Property(e => e.Codigo)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdDepartamento).HasColumnType("int(11)");

            builder.Property(e => e.IdProvincia).HasColumnType("int(11)");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");
        }
    }
}
