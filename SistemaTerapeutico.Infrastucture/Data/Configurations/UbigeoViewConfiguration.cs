using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class UbigeoViewConfiguration : IEntityTypeConfiguration<UbigeoView>
    {
        public void Configure(EntityTypeBuilder<UbigeoView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdUbigeo");
            builder.ToTable("vw_ubigeo");
        }
    }
}
