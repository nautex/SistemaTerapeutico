using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaAntecedenteViewConfiguration : IEntityTypeConfiguration<PersonaAntecedenteView>
    {
        public void Configure(EntityTypeBuilder<PersonaAntecedenteView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_personaantecedente");
        }
    }
}
