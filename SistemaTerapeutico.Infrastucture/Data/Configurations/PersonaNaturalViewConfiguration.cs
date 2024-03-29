﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaNaturalViewConfiguration : IEntityTypeConfiguration<PersonaNaturalView>
    {
        public void Configure(EntityTypeBuilder<PersonaNaturalView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdPersona");
            builder.ToTable("vw_personanatural");
        }
    }
}
