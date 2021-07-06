using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDireccionConfiguration : IEntityTypeConfiguration<PersonaDireccion>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccion> builder)
        {
            builder.HasKey(e => new { e.Id, e.Numero })
                    .HasName("PRIMARY");

            builder.ToTable("personadireccion");


            builder.Property(e => e.Id)
                .HasColumnName("IdPersona")
                .HasColumnType("int(11)");

            builder.Property(e => e.Numero)
                .HasColumnType("int(11)");

            builder.Property(e => e.IdTipoDireccion)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)")
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.HasOne(d => d.IdPersonaNavigation)
                .WithMany(p => p.PersonaDireccion)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonaDireccion_Persona");

        }
    }
}
