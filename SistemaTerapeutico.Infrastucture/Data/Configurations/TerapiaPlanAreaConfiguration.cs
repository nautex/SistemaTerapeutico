using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanAreaConfiguration : BaseEntity2IdsConfiguration<TerapiaPlanArea>, IEntityTypeConfiguration<TerapiaPlanArea>
    {
        public override void Configure(EntityTypeBuilder<TerapiaPlanArea> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdTerapiaPlan");
        }
    }
}
