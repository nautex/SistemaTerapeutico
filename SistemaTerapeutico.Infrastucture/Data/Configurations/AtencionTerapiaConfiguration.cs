using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AtencionTerapiaConfiguration : IEntityTypeConfiguration<AtencionTerapia>
    {
        public void Configure(EntityTypeBuilder<AtencionTerapia> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo });
            builder.Property(x => x.Id).HasColumnName("IdAtencion");
            builder.Property(x => x.IdTwo).HasColumnName("IdTerapia");
        }
    }
}
