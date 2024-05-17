using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaContactoRepository : BaseEntityTwoIdsRepository<PersonaContacto>, IPersonaContactoRepository
    {
        public PersonaContactoRepository(SISDETContext _context) : base(_context)
        {

        }
    }
}