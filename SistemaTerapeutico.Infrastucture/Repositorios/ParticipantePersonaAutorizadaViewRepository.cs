using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipantePersonaAutorizadaViewRepository : BaseEntity2IdsRepository<ParticipantePersonaAutorizadaView>, IParticipantePersonaAutorizadaViewRepository
    {
        public ParticipantePersonaAutorizadaViewRepository(SISDETContext _context) : base(_context)
        {
            
        }
    }
}
