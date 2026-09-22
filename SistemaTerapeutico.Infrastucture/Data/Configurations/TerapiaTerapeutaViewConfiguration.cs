using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaTerapeutaViewConfiguration : BaseEntityTwoIdsConfiguration<TerapiaTerapeutaView>, IEntityTypeConfiguration<TerapiaTerapeutaView>
    {
        public override void Configure(EntityTypeBuilder<TerapiaTerapeutaView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_terapiaterapeuta");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
