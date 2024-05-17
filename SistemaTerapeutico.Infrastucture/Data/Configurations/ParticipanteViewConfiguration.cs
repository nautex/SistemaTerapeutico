using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteViewConfiguration : IEntityTypeConfiguration<ParticipanteView>
    {
        public void Configure(EntityTypeBuilder<ParticipanteView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_participante");
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
