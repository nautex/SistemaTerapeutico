using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteNivelLenguajeConfiguration : BaseEntityTwoIdsConfiguration<ParticipanteNivelLenguaje>, IEntityTypeConfiguration<ParticipanteNivelLenguaje>
    {
        public override void Configure(EntityTypeBuilder<ParticipanteNivelLenguaje> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Id).HasColumnName("IdParticipante").ValueGeneratedNever();
        }
    }
}
