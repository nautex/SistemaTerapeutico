using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionResumenViewConfiguration : IEntityTypeConfiguration<SesionResumenView>
    {
        public void Configure(EntityTypeBuilder<SesionResumenView> builder)
        {
            builder.ToTable("vw_sesionresumen");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdSesion");
        }
    }
}
