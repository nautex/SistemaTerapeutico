using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioConfiguration : BaseEntity2IdsConfiguration<SesionCriterio>, IEntityTypeConfiguration<SesionCriterio>
    {
        public override void Configure(EntityTypeBuilder<SesionCriterio> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdSesion");
        }
    }
}
