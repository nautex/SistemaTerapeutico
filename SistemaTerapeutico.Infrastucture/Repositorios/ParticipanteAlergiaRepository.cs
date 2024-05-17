using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteAlergiaRepository : BaseEntity2IdsRepository<ParticipanteAlergia>, IParticipanteAlergiaRepository
    {
        public ParticipanteAlergiaRepository(SISDETContext _context) : base(_context)
        {
            
        }
    }
}
