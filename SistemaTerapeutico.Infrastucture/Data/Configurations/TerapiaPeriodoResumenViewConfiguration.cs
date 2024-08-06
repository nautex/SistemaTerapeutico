using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPeriodoResumenViewConfiguration : IEntityTypeConfiguration<TerapiaPeriodoResumenView>
    {
        public void Configure(EntityTypeBuilder<TerapiaPeriodoResumenView> builder)
        {
            builder.ToTable("vw_terapiaperiodoresumen");
            builder.HasKey(x  => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdTerapiaPeriodo");
        }
    }
}
