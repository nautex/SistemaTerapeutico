using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPeriodoConfiguration : IEntityTypeConfiguration<TerapiaPeriodo>
    {
        public void Configure(EntityTypeBuilder<TerapiaPeriodo> builder)
        {
            builder.HasKey(x => new { x.Id });
            builder.Property(x => x.Id).HasColumnName("IdTerapiaPeriodo");
        }
    }
}
