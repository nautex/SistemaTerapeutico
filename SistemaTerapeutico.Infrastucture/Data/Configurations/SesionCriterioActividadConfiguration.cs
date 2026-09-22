using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class SesionCriterioActividadConfiguration : IEntityTypeConfiguration<SesionCriterioActividad>
    {
        public void Configure(EntityTypeBuilder<SesionCriterioActividad> builder)
        {
            builder.HasKey(x => new { x.Id, x.Numero, x.IdThree });
            builder.Property(x => x.Id).HasColumnName("IdSesion");
            builder.Property(x => x.Numero).HasColumnName("IdObjetivoCriterio");
            builder.Property(x => x.IdThree).HasColumnName("IdActividad");
        }
    }
}
