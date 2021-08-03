using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaNaturalConfiguration : IEntityTypeConfiguration<PersonaNatural>
    {
        public void Configure(EntityTypeBuilder<PersonaNatural> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona");

            //builder.HasOne(d => d.IdPersonaNavigation)
            //    .WithOne(p => p.PersonaNatural)
            //    .HasForeignKey<PersonaNatural>(d => d.Id)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_PersonaNatural_Persona1");

            //builder.HasOne(d => d.IdUbigeoNacimientoNavigation)
            //    .WithMany(p => p.PersonaNatural)
            //    .HasForeignKey(d => d.IdUbigeoNacimiento)
            //    .HasConstraintName("FK_PersonaNatural_Ubigeo");
        }
    }
}
