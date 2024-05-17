using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class LocalViewConfiguration : BaseEntityConfiguration<LocalView>, IEntityTypeConfiguration<LocalView>
    {
        public override void Configure(EntityTypeBuilder<LocalView> builder)
        {
            base.Configure(builder);
            builder.Property(x =>  x.Id).HasColumnName("IdLocal");
            builder.ToTable("vw_local");
        }
    }
}
