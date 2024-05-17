using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaParticipanteViewConfiguration : BaseEntity2IdsConfiguration<TerapiaParticipanteView>, IEntityTypeConfiguration<TerapiaParticipanteView>
    {
        public override void Configure(EntityTypeBuilder<TerapiaParticipanteView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_terapiaparticipante");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");
        }
    }
}
