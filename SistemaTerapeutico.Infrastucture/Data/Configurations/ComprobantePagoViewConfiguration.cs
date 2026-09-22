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
    public class ComprobantePagoViewConfiguration : BaseEntityTwoIdsConfiguration<ComprobantePagoView>, IEntityTypeConfiguration<ComprobantePagoView>
    {
        public override void Configure(EntityTypeBuilder<ComprobantePagoView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_comprobantepago");
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
        }
    }
}
