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

            builder.ToTable("Direccion");

            builder.Property(e => e.Id)
                .HasColumnName("IdDireccion")
                .HasColumnType("int(11)");

            builder.Property(e => e.IdUbigeo)
                .HasColumnName("IdUbigeo")
                .HasColumnType("int(11)");

            builder.HasIndex(e => e.IdUbigeo)
                .HasName("FK_direccion_ubigeo");

            builder.Property(e => e.Detalle)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'");

        }
    }
}
