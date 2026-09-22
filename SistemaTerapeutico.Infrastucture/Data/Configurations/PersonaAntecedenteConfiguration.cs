using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaAntecedenteConfiguration : BaseEntityTwoIdsConfiguration<PersonaAntecedente>, IEntityTypeConfiguration<PersonaAntecedente>
    {
        public override void Configure(EntityTypeBuilder<PersonaAntecedente> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("IdPersona");
        }
    }
}
