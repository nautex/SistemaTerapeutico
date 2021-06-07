using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaContactoConfiguration : IEntityTypeConfiguration<PersonaContacto>
    {
        public void Configure(EntityTypeBuilder<PersonaContacto> builder)
        {
            builder.HasKey(e => new { e.IdPersona, e.Numero })
                    .HasName("PRIMARY");

            builder.ToTable("personacontacto");

            builder.Property(e => e.IdPersona).HasColumnType("int(11)");

            builder.Property(e => e.Numero).HasColumnType("int(11)");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdTipoContacto)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Valor)
                .HasMaxLength(120)
                .HasDefaultValueSql("'NULL'");

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaContacto)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaContacto_Persona");
        }
    }
}
