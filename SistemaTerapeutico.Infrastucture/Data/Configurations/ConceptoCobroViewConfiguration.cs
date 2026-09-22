using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ConceptoCobroViewConfiguration : IEntityTypeConfiguration<ConceptoCobroView>
    {
        public void Configure(EntityTypeBuilder<ConceptoCobroView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("vw_conceptocobro");
            builder.Property(x => x.Id).HasColumnName("IdConceptoCobro");
        }
    }
}
