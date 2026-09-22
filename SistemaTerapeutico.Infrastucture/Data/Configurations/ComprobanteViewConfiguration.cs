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
    public class ComprobanteViewConfiguration : IEntityTypeConfiguration<ComprobanteView>
    {
        public void Configure(EntityTypeBuilder<ComprobanteView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_comprobante");
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
        }
    }
}
