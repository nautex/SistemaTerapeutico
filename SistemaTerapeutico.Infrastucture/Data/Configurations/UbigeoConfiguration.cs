using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdUbigeo");
        }
    }
}
