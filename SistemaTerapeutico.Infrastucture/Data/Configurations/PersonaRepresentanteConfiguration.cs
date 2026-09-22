using SistemaTerapeutico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaRepresentanteConfiguration : IEntityTypeConfiguration<PersonaRepresentante>
    {
        public void Configure(EntityTypeBuilder<PersonaRepresentante> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("IdPersonaRepresentante");
        }
    }
}
