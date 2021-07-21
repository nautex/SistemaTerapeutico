using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioConfiguration : IEntityTypeConfiguration<SesionCriterio>
    {
        public void Configure(EntityTypeBuilder<SesionCriterio> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdSesionCriterio");
        }
    }
}
