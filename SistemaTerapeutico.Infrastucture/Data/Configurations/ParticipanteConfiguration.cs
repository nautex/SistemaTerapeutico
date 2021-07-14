﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class ParticipanteConfiguration : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("PRIMARY");
            builder.ToTable("participante");
            builder.Property(e => e.TieneDiagnostico)
                .HasColumnType("bit")
                .HasDefaultValueSql("'NULL'");
        }
    }
}