using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaVinculacionConfiguration : IEntityTypeConfiguration<PersonaVinculacion>
    {
        public void Configure(EntityTypeBuilder<PersonaVinculacion> builder)
        {
            builder.HasKey(e => new { e.Id, e.IdTwo })
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona");

            builder.Property(e => e.IdTwo)
                .HasColumnName("IdPersonaVinculo");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithMany(p => p.PersonaVinculacionIdPersonaNavigation)
            //    .HasForeignKey(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaVinculacion_Persona");

            //builder.HasOne(d => d.IdTwoNavigation)
            //    .WithMany(p => p.PersonaVinculacionIdTwoNavigation)
            //    .HasForeignKey(d => d.IdTwo)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaVinculacion_Persona1");
        }
    }
}
