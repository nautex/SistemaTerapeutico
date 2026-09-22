using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class CargoViewConfiguration : IEntityTypeConfiguration<CargoView>
    {
        public void Configure(EntityTypeBuilder<CargoView> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdCargo");
            builder.ToView("vw_cargo");
        }
    }
}
