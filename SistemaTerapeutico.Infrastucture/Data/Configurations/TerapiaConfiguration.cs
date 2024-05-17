using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class TerapiaConfiguration : IEntityTypeConfiguration<Terapia>
    {
        public void Configure(EntityTypeBuilder<Terapia> builder)
        {
            builder.HasKey(x => x.Id).HasName("PRIMARY");
            builder.Property(x => x.Id).HasColumnName("IdTerapia");

            builder.Ignore(e => e.TerapiaHorario);
            builder.Ignore(e => e.TerapiaTerapeuta);
            builder.Ignore(e => e.TerapiaParticipante);
        }
    }
}
