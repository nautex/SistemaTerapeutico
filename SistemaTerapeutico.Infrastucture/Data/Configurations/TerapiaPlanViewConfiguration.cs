using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanViewConfiguration : IEntityTypeConfiguration<TerapiaPlanView>
    {
        public void Configure(EntityTypeBuilder<TerapiaPlanView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdTerapiaPlan");
            builder.ToTable("vw_terapiaplan");
        }
    }
}
