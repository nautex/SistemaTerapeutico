using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteAlergiaViewRepository : BaseEntity2IdsRepository<ParticipanteAlergiaView>, IParticipanteAlergiaViewRepository
    {
        public ParticipanteAlergiaViewRepository(SISDETContext _context) : base(_context)
        {
            
        }
    }
}
