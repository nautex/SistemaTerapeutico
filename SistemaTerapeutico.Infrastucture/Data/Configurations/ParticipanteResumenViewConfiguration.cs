using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteResumenViewConfiguration : IEntityTypeConfiguration<ParticipanteResumenView>
    {
        public void Configure(EntityTypeBuilder<ParticipanteResumenView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_participanteresumen");
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
