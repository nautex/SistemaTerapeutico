using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class CatalogoConfiguration : IEntityTypeConfiguration<Catalogo>
    {
        public void Configure(EntityTypeBuilder<Catalogo> builder)
        {
            builder.ToTable("Catalogo");

            builder.HasKey(e => e.Id)
                    .HasName("PRIMARY");

            builder.Property(e => e.Id)
                .HasColumnName("IdCatalogo")
                .HasColumnType("int(11)");
        }
    }
}
