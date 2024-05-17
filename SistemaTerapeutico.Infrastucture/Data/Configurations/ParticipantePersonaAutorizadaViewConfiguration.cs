using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipantePersonaAutorizadaViewConfiguration : BaseEntity2IdsConfiguration<ParticipantePersonaAutorizadaView>, IEntityTypeConfiguration<ParticipantePersonaAutorizadaView>
    {
        public override void Configure(EntityTypeBuilder<ParticipantePersonaAutorizadaView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_participantepersonaautorizada");
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
