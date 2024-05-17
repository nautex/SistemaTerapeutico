using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaHorarioConfiguration : BaseEntity2IdsConfiguration<TerapiaHorario>, IEntityTypeConfiguration<TerapiaHorario>
    {
        public override void Configure(EntityTypeBuilder<TerapiaHorario> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
