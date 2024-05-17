using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaParticipanteRepository : BaseEntity2IdsRepository<TerapiaParticipante>, ITerapiaParticipanteRepository
    {
        public TerapiaParticipanteRepository(SISDETContext context) : base(context)
        {
        }
    }
}
