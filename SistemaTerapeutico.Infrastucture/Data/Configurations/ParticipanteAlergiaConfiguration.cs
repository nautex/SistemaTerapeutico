using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteAlergiaConfiguration : BaseEntity2IdsConfiguration<ParticipanteAlergia>, IEntityTypeConfiguration<ParticipanteAlergia>
    {
        public override void Configure(EntityTypeBuilder<ParticipanteAlergia> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
