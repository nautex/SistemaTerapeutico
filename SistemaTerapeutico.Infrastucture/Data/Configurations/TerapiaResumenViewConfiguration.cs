using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaResumenViewConfiguration : IEntityTypeConfiguration<TerapiaResumenView>
    {
        public void Configure(EntityTypeBuilder<TerapiaResumenView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_terapiaresumen");
        }
    }
}
