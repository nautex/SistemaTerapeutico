using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaResumenViewConfiguration : IEntityTypeConfiguration<PersonaResumenView>
    {
        public void Configure(EntityTypeBuilder<PersonaResumenView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdPersona");
            builder.ToTable("vw_personaresumen");
        }
    }
}
