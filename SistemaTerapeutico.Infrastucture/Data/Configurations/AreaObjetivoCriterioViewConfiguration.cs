using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaObjetivoCriterioViewConfiguration : IEntityTypeConfiguration<AreaObjetivoCriterioView>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivoCriterioView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdAreaObjetivoCriterio");
            builder.ToTable("vw_areaobjetivocriterio");
        }
    }
}
