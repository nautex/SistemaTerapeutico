using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaViewConfiguration : IEntityTypeConfiguration<AreaView>
    {
        public void Configure(EntityTypeBuilder<AreaView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_area");
            builder.Property(x => x.Id).HasColumnName("IdArea");
        }
    }
}
