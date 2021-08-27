using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaVinculacionViewConfiguration : IEntityTypeConfiguration<PersonaVinculacionView>
    {
        public void Configure(EntityTypeBuilder<PersonaVinculacionView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personavinculacion");
        }
    }
}
