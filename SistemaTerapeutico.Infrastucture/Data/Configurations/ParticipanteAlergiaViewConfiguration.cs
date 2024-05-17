using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteAlergiaViewConfiguration : BaseEntity2IdsConfiguration<ParticipanteAlergiaView>, IEntityTypeConfiguration<ParticipanteAlergiaView>
    {
        public override void Configure(EntityTypeBuilder<ParticipanteAlergiaView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_participantealergia");
            builder.Property(e => e.Id).HasColumnName("IdParticipante");
        }
    }
}
