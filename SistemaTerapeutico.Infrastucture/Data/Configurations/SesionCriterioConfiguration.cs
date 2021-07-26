using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioConfiguration : IEntityTypeConfiguration<SesionCriterio>
    {
        public void Configure(EntityTypeBuilder<SesionCriterio> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo }).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdSesion");
            builder.Property(x => x.IdTwo).HasColumnName("IdObjetivoCriterio");
        }
    }
}
