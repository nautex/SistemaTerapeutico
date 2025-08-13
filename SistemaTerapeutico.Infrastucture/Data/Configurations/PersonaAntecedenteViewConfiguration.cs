using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaAntecedenteViewConfiguration : BaseEntity2IdsConfiguration<PersonaAntecedenteView>, IEntityTypeConfiguration<PersonaAntecedenteView>
    {
        public override void Configure(EntityTypeBuilder<PersonaAntecedenteView> builder)
        {
            base.Configure(builder);
            builder.ToTable("vw_personaantecedente");
            builder.Property(x => x.Id).HasColumnName("IdPersona");
        }
    }
}
