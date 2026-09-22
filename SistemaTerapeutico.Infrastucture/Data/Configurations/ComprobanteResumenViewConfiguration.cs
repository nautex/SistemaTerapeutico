using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ComprobanteResumenViewConfiguration : IEntityTypeConfiguration<ComprobanteResumenView>
    {
        public void Configure(EntityTypeBuilder<ComprobanteResumenView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
            builder.ToTable("vw_comprobanteresumen");
        }
    }
}
