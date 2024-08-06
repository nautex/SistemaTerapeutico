using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioViewConfiguration : BaseEntity2IdsConfiguration<SesionCriterioView>, IEntityTypeConfiguration<SesionCriterioView>
    {
        public override void Configure(EntityTypeBuilder<SesionCriterioView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_sesioncriterio");
            builder.Property(x => x.Id).HasColumnName("IdSesion");
            builder.Ignore(e => e.AreaObjetivo);
            builder.Ignore(e => e.AreaObjetivoCriterio);
        }
    }
}
