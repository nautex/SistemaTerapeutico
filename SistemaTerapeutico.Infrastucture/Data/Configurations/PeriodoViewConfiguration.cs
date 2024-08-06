using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PeriodoViewConfiguration : IEntityTypeConfiguration<PeriodoView>
    {
        public void Configure(EntityTypeBuilder<PeriodoView> builder)
        {
            builder.ToTable("vw_periodo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdPeriodo");
        }
    }
}
