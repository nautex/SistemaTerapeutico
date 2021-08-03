using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaContactoConfiguration : IEntityTypeConfiguration<PersonaContacto>
    {
        public void Configure(EntityTypeBuilder<PersonaContacto> builder)
        {
            builder.HasKey(e => new { e.Id, e.IdTwo })
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona");

            builder.Property(e => e.IdTwo)
                .HasColumnName("Numero");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithMany(p => p.PersonaContacto)
            //    .HasForeignKey(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaContacto_Persona");
        }
    }
}
