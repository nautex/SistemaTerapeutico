using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionConfiguration : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdSesion");
            builder.Ignore(e => e.SesionTerapeuta);
            builder.Ignore(e => e.SesionCriterio);
        }
    }
}
