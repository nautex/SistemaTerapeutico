using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipantePersonaAutorizadaConfiguration : BaseEntity2IdsConfiguration<ParticipantePersonaAutorizada>, IEntityTypeConfiguration<ParticipantePersonaAutorizada>
    {
        public override void Configure(EntityTypeBuilder<ParticipantePersonaAutorizada> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
