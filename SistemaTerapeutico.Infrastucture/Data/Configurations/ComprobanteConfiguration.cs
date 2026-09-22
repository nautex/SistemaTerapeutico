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
    public class ComprobanteConfiguration : IEntityTypeConfiguration<Comprobante>
    {
        public void Configure(EntityTypeBuilder<Comprobante> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdComprobante");

            builder.Ignore(e => e.ComprobanteDetalle);
            builder.Ignore(e => e.ComprobantePago);
        }
    }
}
