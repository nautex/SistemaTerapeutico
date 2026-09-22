using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDocumentoConfiguration : IEntityTypeConfiguration<PersonaDocumento>
    {
        public void Configure(EntityTypeBuilder<PersonaDocumento> builder)
        {
            builder.HasKey(e => new { e.Id, e.Numero })
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona");

            builder.Property(e => e.Numero)
                .HasColumnName("Numero");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithMany(p => p.PersonaDocumento)
            //    .HasForeignKey(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaDocumento_Persona");
        }
    }
}
