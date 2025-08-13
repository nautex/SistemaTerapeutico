using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaObjetivoCriterioViewConfiguration : IEntityTypeConfiguration<AreaObjetivoCriterioView>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivoCriterioView> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("vw_areaobjetivocriterio");

            builder.Property(x => x.Id).HasColumnName("IdAreaObjetivoCriterio");
        }
    }
}
