using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionViewConfiguration : IEntityTypeConfiguration<SesionView>
    {
        public void Configure(EntityTypeBuilder<SesionView> builder)
        {
            builder.ToTable("vw_sesion");
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdSesion");
        }
    }
}
