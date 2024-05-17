using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaParticipanteConfiguration : BaseEntity2IdsConfiguration<TerapiaParticipante>, IEntityTypeConfiguration<TerapiaParticipante>
    {
        public override void Configure(EntityTypeBuilder<TerapiaParticipante> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
