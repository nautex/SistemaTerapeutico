using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaVinculacionConfiguration : IEntityTypeConfiguration<PersonaVinculacion>
    {
        public void Configure(EntityTypeBuilder<PersonaVinculacion> builder)
        {
            builder.HasKey(e => new { e.Id, e.IdPersonaVinculo })
                    .HasName("PRIMARY");

            builder.ToTable("personavinculacion");

            builder.HasIndex(e => e.IdPersonaVinculo)
                .HasName("FK_PersonaVinculacion_Persona1");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona")
                .HasColumnType("int(11)");

            builder.Property(e => e.IdPersonaVinculo).HasColumnType("int(11)");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdTipoVinculo)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithMany(p => p.PersonaVinculacionIdPersonaNavigation)
            //    .HasForeignKey(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaVinculacion_Persona");

            //builder.HasOne(d => d.IdPersonaVinculoNavigation)
            //    .WithMany(p => p.PersonaVinculacionIdPersonaVinculoNavigation)
            //    .HasForeignKey(d => d.IdPersonaVinculo)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaVinculacion_Persona1");
        }
    }
}
