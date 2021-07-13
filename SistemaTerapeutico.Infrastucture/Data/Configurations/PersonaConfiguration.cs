using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.ToTable("persona");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona")
                .HasColumnType("int(11)");

            builder.Property(e => e.IdEstado)
                .HasColumnType("int(11)");

            builder.Property(e => e.IdPaisOrigen)
                .HasColumnType("int(11)");

            builder.Property(e => e.EsEmpresa)
                .HasColumnType("bit");

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(e => e.RazonSocial)
                .HasMaxLength(200);

            builder.Property(e => e.UsuarioModificacion)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");

            builder.Property(e => e.UsuarioRegistro)
                .HasMaxLength(20)
                .HasDefaultValueSql("'NULL'");
        }
    }
}
