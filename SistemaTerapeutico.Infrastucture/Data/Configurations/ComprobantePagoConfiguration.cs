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
    public class ComprobantePagoConfiguration : BaseEntityTwoIdsConfiguration<ComprobantePago>, IEntityTypeConfiguration<ComprobantePago>
    {
        public override void Configure(EntityTypeBuilder<ComprobantePago> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdComprobante");
        }
    }
}
