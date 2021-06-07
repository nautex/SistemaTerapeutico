using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDocumentoConfiguration : IEntityTypeConfiguration<PersonaDocumento>
    {
        public void Configure(EntityTypeBuilder<PersonaDocumento> builder)
        {
            builder.HasKey(e => new { e.IdPersona, e.IdTipoDocumento })
                    .HasName("PRIMARY");

            builder.ToTable("personadocumento");

            builder.Property(e => e.IdPersona).HasColumnType("int(11)");

            builder.Property(e => e.IdTipoDocumento).HasColumnType("int(11)");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.Numero)
                .HasMaxLength(40)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDocumento)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDocumento_Persona");
        }
    }
}
