using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class FilialViewConfiguration : BaseEntityConfiguration<FilialView>, IEntityTypeConfiguration<FilialView>
    {
        public override void Configure(EntityTypeBuilder<FilialView> builder)
        {
            base.Configure(builder);
            builder.Property(x =>  x.Id).HasColumnName("IdFilial");
            builder.ToTable("vw_filial");
        }
    }
}
