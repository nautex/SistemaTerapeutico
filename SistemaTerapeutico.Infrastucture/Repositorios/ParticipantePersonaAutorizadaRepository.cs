using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipantePersonaAutorizadaRepository : BaseEntity2IdsRepository<ParticipantePersonaAutorizada>, IParticipantePersonaAutorizadaRepository
    {
        public ParticipantePersonaAutorizadaRepository(SISDETContext _context) : base(_context)
        {
            
        }
    }
}
