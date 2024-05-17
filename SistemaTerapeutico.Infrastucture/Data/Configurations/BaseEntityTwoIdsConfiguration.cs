using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class BaseEntityTwoIdsConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntityTwoIds
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => new { e.Id, e.IdTwo }).HasName("PRIMARY");
            builder.Property(e => e.IdTwo).HasColumnName("Numero");
        }
    }
}
