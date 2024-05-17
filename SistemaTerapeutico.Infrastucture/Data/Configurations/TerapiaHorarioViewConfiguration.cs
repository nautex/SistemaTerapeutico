using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaHorarioViewConfiguration : BaseEntity2IdsConfiguration<TerapiaHorarioView>, IEntityTypeConfiguration<TerapiaHorarioView>
    {
        public override void Configure(EntityTypeBuilder<TerapiaHorarioView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_terapiahorario");
            builder.Property(x =>  x.Id).HasColumnName("IdTerapia");
        }
    }
}
