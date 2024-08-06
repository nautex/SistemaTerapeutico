using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PuntuacionGrupoConfiguration : IEntityTypeConfiguration<PuntuacionGrupo>
    {
        public void Configure(EntityTypeBuilder<PuntuacionGrupo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdPuntuacionGrupo");
        }
    }
}
