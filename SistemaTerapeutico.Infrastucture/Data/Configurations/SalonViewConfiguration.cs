using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SalonViewConfiguration : BaseEntityConfiguration<SalonView>, IEntityTypeConfiguration<SalonView>
    {
        public override void Configure(EntityTypeBuilder<SalonView> builder)
        {
            builder.Property(x => x.Id).HasColumnName("IdSalon");
            builder.ToTable("vw_salon");
        }
    }
}
