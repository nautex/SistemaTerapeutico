using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TarifaConfiguration : IEntityTypeConfiguration<Tarifa>
    {
        public void Configure(EntityTypeBuilder<Tarifa> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdTarifa");
        }
    }
}
