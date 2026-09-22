using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class AreaObjetivoViewConfiguration : IEntityTypeConfiguration<AreaObjetivoView>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivoView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_areaobjetivo");
            builder.Property(x => x.Id).HasColumnName("IdAreaObjetivo");
        }
    }
}
