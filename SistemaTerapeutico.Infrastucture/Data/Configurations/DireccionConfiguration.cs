using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdDireccion")
                .HasColumnType("int(11)");
        }
    }
}
