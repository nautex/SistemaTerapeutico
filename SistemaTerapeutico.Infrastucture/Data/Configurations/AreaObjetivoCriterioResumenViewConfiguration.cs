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
    public class AreaObjetivoCriterioResumenViewConfiguration : IEntityTypeConfiguration<AreaObjetivoCriterioResumenView>
    {
        public void Configure(EntityTypeBuilder<AreaObjetivoCriterioResumenView> builder)
        {
            builder.ToTable("vw_areaobjetivocriterioresumen");
            builder.HasKey(x => x.Id);
        }
    }
}
