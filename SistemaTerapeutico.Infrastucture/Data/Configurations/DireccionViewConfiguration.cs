using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class DireccionViewConfiguration : IEntityTypeConfiguration<DireccionView>
    {
        public void Configure(EntityTypeBuilder<DireccionView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdDireccion");
            builder.ToTable("vw_direccion");
        }
    }
}
