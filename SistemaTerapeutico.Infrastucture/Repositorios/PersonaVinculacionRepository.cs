using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaVinculacionRepository : BaseRepositoryTwoIds<PersonaVinculacion>, IPersonaVinculacionRepository
    {
        public PersonaVinculacionRepository(SISDETContext _context) : base(_context)
        {

        }
    }
}
