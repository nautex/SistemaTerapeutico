using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaTerapeutaConfiguracion : BaseEntity2IdsConfiguration<TerapiaTerapeuta>, IEntityTypeConfiguration<TerapiaTerapeuta>
    {
        public override void Configure(EntityTypeBuilder<TerapiaTerapeuta> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
