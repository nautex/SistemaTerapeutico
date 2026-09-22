using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Data.Configurations
{
    public class PersonaJuridicaViewConfiguration : IEntityTypeConfiguration<PersonaJuridicaView>
    {
        public void Configure(EntityTypeBuilder<PersonaJuridicaView> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("IdPersona");
            builder.ToView("vw_personajuridica");
        }
    }
}
