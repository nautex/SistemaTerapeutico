using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaVinculacionRepository : BaseEntityTwoIdsRepository<PersonaVinculacion>, IPersonaVinculacionRepository
    {
        public PersonaVinculacionRepository(SISDETContext _context) : base(_context)
        {

        }
        public async Task<IEnumerable<PersonaVinculacion>> GetsPersonaVinculacionTwoPersons(int idPersona, int idPersonaVinculo)
        {
            return await _entities.Where(x => (x.Id == idPersona && x.IdPersonaVinculo == idPersonaVinculo) || (x.IdPersonaVinculo == idPersona && x.Id == idPersonaVinculo)).ToListAsync();
        }
    }
}
