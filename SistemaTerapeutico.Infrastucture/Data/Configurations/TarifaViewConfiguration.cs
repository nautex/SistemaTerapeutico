using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TarifaViewConfiguration : IEntityTypeConfiguration<TarifaView>
    {
        public void Configure(EntityTypeBuilder<TarifaView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_tarifa");
            builder.Property(x => x.Id).HasColumnName("IdTarifa");
        }
    }
}
