using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class BaseEntity2IdsConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity2Ids
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => new { e.Id, e.Numero }).HasName("PRIMARY");
        }
    }
}
