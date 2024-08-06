using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanResumenViewConfiguration : IEntityTypeConfiguration<TerapiaPlanResumenView>
    {
        public void Configure(EntityTypeBuilder<TerapiaPlanResumenView> builder)
        {
            builder.ToTable("vw_terapiaplanresumen");
            builder.HasKey(t => t.Id);
        }
    }
}
