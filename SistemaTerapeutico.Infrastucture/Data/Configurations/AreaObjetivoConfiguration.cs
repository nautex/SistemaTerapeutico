using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaObjetivoConfiguration : IEntityTypeConfiguration<AreaObjetivo>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdAreaObjetivo");

            builder.Ignore(e => e.AreaObjetivoCriterio);
        }
    }
}
