using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaResumenBasicoViewConfiguration : IEntityTypeConfiguration<PersonaResumenBasicoView>
    {
        public void Configure(EntityTypeBuilder<PersonaResumenBasicoView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personaresumenbasico");
        }
    }
}
