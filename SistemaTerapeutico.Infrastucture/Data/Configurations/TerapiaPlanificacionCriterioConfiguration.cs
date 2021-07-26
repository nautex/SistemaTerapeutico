using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanificacionCriterioConfiguration : IEntityTypeConfiguration<TerapiaPlanificacionCriterio>
    {
        public void Configure(EntityTypeBuilder<TerapiaPlanificacionCriterio> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo, x.IdThree }).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
            builder.Property(x => x.IdTwo).HasColumnName("IdPeriodo");
            builder.Property(x => x.IdThree).HasColumnName("IdObjetivoCriterio");
        }
    }
}
