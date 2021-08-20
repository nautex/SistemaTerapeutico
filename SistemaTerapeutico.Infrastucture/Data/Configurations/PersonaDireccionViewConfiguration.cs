using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDireccionViewConfiguration : IEntityTypeConfiguration<PersonaDireccionView>
    {
        public void Configure(EntityTypeBuilder<PersonaDireccionView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personadireccion");
        }
    }
}
