using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioActividadConfiguration : IEntityTypeConfiguration<SesionCriterioActividad>
    {
        public void Configure(EntityTypeBuilder<SesionCriterioActividad> builder)
        {
            builder.HasKey(x => new { x.Id, x.IdTwo });
            builder.Property(x => x.Id).HasColumnName("IdSesionCriterio");
            builder.Property(x => x.IdTwo).HasColumnName("IdActividad");
        }
    }
}
