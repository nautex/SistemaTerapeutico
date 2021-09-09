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

            builder.Property(e => e.Id)
                .HasColumnName("IdPersona")
                .ValueGeneratedNever();

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(70);

            //builder.HasOne(f => f.PersonaNatural)
            //    .WithOne()
            //    .HasForeignKey<Persona>(f => f.Id);

            //builder.HasMany(f => f.PersonaDireccion)
            //    .WithOne()
            //    .HasForeignKey(f => f.Id);

            //builder.HasMany(f => f.PersonaDocumento)
            //    .WithOne()
            //    .HasForeignKey(f => f.Id);

            //builder.HasMany(f => f.PersonaContacto)
            //    .WithOne()
            //    .HasForeignKey(f => f.Id);

            //builder.HasMany(f => f.PersonaVinculacion)
            //    .WithOne()
            //    .HasForeignKey(f => f.Id);
        }
    }
}
