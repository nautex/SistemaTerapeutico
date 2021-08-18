using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaDocumentoViewConfiguration : IEntityTypeConfiguration<PersonaDocumentoView>
    {
        public void Configure(EntityTypeBuilder<PersonaDocumentoView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personadocumento");
        }
    }
}
//12345678910111213141516171819202122232425262728293031323334353637383940