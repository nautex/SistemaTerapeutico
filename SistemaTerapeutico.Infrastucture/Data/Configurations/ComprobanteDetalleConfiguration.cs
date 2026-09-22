using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ComprobanteDetalleConfiguration : BaseEntityTwoIdsConfiguration<ComprobanteDetalle>, IEntityTypeConfiguration<ComprobanteDetalle>
    {
        public override void Configure(EntityTypeBuilder<ComprobanteDetalle> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
        }
    }
}
