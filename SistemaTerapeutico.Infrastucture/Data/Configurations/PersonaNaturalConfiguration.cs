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

            //builder.Ignore(e => e.IsNewRow);
            //builder.Ignore(e => e.IsUpdated);

            //builder.HasOne(d => d.Id)
            //    .WithOne(p => p.PersonaNatural);



            //builder.HasOne(d => d.IdUbigeoNacimientoNavigation)
            //    .WithMany(p => p.PersonaNatural)
            //    .HasForeignKey(d => d.IdUbigeoNacimiento)
            //    .HasConstraintName("FK_PersonaNatural_Ubigeo");
        }
    }
}
