using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionTerapeutaViewConfiguration : BaseEntity2IdsConfiguration<SesionTerapeutaView>, IEntityTypeConfiguration<SesionTerapeutaView>
    {
        public override void Configure(EntityTypeBuilder<SesionTerapeutaView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_sesionterapeuta");
            builder.Property(x => x.Id).HasColumnName("IdSesion");
        }
    }
}
