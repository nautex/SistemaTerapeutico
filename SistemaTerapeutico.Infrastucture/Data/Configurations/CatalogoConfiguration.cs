using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class CatalogoConfiguration : IEntityTypeConfiguration<Catalogo>
    {
        public void Configure(EntityTypeBuilder<Catalogo> builder)
        {
            builder.HasKey(e => e.IdCatalogo)
                    .HasName("PRIMARY");

            builder.ToTable("catalogo");

            builder.Property(e => e.IdCatalogo).HasColumnType("int(11)");

            builder.Property(e => e.Abreviado)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Codigo)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdPadre)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Orden)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");
        }
    }
}
