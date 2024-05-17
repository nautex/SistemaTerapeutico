using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaViewConfiguration : IEntityTypeConfiguration<TerapiaView>
    {
        public void Configure(EntityTypeBuilder<TerapiaView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_terapia");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
