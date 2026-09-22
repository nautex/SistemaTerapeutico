using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteNivelLenguajeViewConfiguration : BaseEntityTwoIdsConfiguration<ParticipanteNivelLenguajeView>, IEntityTypeConfiguration<ParticipanteNivelLenguajeView>
    {
        public override void Configure(EntityTypeBuilder<ParticipanteNivelLenguajeView> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Id).HasColumnName("IdParticipante");
            builder.ToTable("vw_participantenivellenguaje");
        }
    }
}
