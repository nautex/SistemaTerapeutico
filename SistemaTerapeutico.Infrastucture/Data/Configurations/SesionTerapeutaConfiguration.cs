using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionTerapeutaConfiguration : BaseEntity2IdsConfiguration<SesionTerapeuta>, IEntityTypeConfiguration<SesionTerapeuta>
    {
        public override void Configure(EntityTypeBuilder<SesionTerapeuta> builder)
        {
            base.Configure(builder);
            builder.Property(x  => x.Id).HasColumnName("IdSesion");
        }
    }
}
