using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaPlanificacionConfiguration : IEntityTypeConfiguration<TerapiaPlanificacion>
    {
        public void Configure(EntityTypeBuilder<TerapiaPlanificacion> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo }).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
            builder.Property(x => x.IdTwo).HasColumnName("IdPeriodo");
        }
    }
}
