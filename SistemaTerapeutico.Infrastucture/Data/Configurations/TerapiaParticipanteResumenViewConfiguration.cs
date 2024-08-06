using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaParticipanteResumenViewConfiguration : IEntityTypeConfiguration<TerapiaParticipanteResumenView>
    {
        public void Configure(EntityTypeBuilder<TerapiaParticipanteResumenView> builder)
        {
            builder.ToTable("vw_terapiaparticipanteresumen");
            builder.HasKey(x => x.Id);
            builder.Ignore(e => e.EstadoCreacion);
        }
    }
}
