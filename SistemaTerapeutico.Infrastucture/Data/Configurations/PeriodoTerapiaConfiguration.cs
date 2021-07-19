using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PeriodoTerapiaConfiguration : IEntityTypeConfiguration<PeriodoTerapia>
    {
        public void Configure(EntityTypeBuilder<PeriodoTerapia> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdPeriodoTerapia");
        }
    }
}
