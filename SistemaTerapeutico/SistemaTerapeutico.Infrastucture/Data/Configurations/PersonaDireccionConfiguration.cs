using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDireccionConfiguration : IEntityTypeConfiguration<PersonaDireccion>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccion> builder)
        {
            builder.HasKey(e => new { e.IdPersona, e.Numero })
                    .HasName("PRIMARY");

            builder.ToTable("personadireccion");

            builder.HasIndex(e => e.IdUbigeo)
                .HasName("FK_PersonaDireccion_Ubigeo");

            builder.Property(e => e.IdPersona).HasColumnType("int(11)");

            builder.Property(e => e.Numero).HasColumnType("int(11)");

            builder.Property(e => e.Detalle)
                .HasMaxLength(400)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdUbigeo)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Referencia)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDireccion)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");

            builder.HasOne(d => d.IdUbigeoNavigation)
                .WithMany(p => p.PersonaDireccion)
                .HasForeignKey(d => d.IdUbigeo)
                .HasConstraintName("FK_PersonaDireccion_Ubigeo");
        }
    }
}
