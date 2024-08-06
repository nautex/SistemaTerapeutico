using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanAreaViewConfiguration : BaseEntity2IdsConfiguration<TerapiaPlanAreaView>, IEntityTypeConfiguration<TerapiaPlanAreaView>
    {
        public override void Configure(EntityTypeBuilder<TerapiaPlanAreaView> builder)
        {
            builder.Property(x => x.Id).HasColumnName("IdTerapiaPlan");
            builder.ToTable("vw_terapiaplanarea");
            builder.Ignore(e => e.ModeloArea);
        }
    }
}
