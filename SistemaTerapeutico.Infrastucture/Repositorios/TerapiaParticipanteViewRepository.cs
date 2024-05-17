using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaParticipanteViewRepository : BaseEntity2IdsRepository<TerapiaParticipanteView>, ITerapiaParticipanteViewRepository
    {
        public TerapiaParticipanteViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
