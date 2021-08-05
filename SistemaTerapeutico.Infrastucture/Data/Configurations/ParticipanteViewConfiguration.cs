using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteViewConfiguration : IEntityTypeConfiguration<ParticipanteView>
    {
        public void Configure(EntityTypeBuilder<ParticipanteView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("VW_ListaParticipantes");
            builder.Property(x => x.Id).HasColumnName("IdParticipante");
        }
    }
}
