using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaObjetivoCriterioConfiguration : IEntityTypeConfiguration<AreaObjetivoCriterio>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivoCriterio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdAreaObjetivoCriterio");
        }
    }
}
