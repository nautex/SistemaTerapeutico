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
    public class ComprobanteDetalleViewConfiguration : BaseEntityTwoIdsConfiguration<ComprobanteDetalleView>, IEntityTypeConfiguration<ComprobanteDetalleView>
    {
        public override void Configure(EntityTypeBuilder<ComprobanteDetalleView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_comprobantedetalle");
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
        }
    }
}
