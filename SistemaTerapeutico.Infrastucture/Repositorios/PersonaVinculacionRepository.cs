using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaVinculacionRepository : BaseRepository<PersonaVinculacion>, IPersonaVinculacionRepository
    {
        public PersonaVinculacionRepository(SISDETContext _context) : base(_context)
        {

        }
        //123456789101112131415161718192021222324252627282930
        public async Task<PersonaVinculacion> GetByIds(int id, int idPersonaVinculo)
        {
            return await _entities.Where(x => x.Id == id && x.IdPersonaVinculo == idPersonaVinculo).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PersonaVinculacion>> GetsById(int id)
        {
            return await _entities.Where(x => x.Id == id).ToListAsync();
        }
        public async Task DeleteByIds(int id, int idPersonaVinculo)
        {
            PersonaVinculacion entity = await GetByIds(id, idPersonaVinculo);

            _context.Remove(entity);
        }
        public async Task DeletesById(int id)
        {
            IEnumerable<PersonaVinculacion> entities = await GetsById(id);

            _context.RemoveRange(entities);
        }
    }
}
