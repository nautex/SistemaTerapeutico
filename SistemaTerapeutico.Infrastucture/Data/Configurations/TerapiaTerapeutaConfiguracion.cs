using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaTerapeutaConfiguracion : IEntityTypeConfiguration<TerapiaTerapeuta>
    {
        public void Configure(EntityTypeBuilder<TerapiaTerapeuta> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo }).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
            builder.Property(x => x.IdTwo).HasColumnName("IdTerapeuta");
        }
    }
}
