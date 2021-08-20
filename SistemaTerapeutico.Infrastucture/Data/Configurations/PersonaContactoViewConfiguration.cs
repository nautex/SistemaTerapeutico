using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaContactoViewConfiguration : IEntityTypeConfiguration<PersonaContactoView>
    {
        public void Configure(EntityTypeBuilder<PersonaContactoView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personacontacto");
        }
    }
}
