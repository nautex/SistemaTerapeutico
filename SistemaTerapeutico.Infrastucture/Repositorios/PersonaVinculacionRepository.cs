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

        public async Task<PersonaVinculacion> GetByIds(int id, int idPersonaVinculo)
        {
            IQueryable<PersonaVinculacion> listado =
                from pd in _entities
                where pd.Id == id && pd.IdPersonaVinculo == idPersonaVinculo
                select pd;

            return await listado.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionsByIdPersonaVinculo(int idPersonaVinculo)
        {
            IQueryable<PersonaVinculacion> listado =
                from pd in _entities
                where pd.IdPersonaVinculo == idPersonaVinculo
                select pd;

            return await listado.ToListAsync();
        }

        public async Task<IEnumerable<PersonaVinculacion>> GetsById(int id)
        {
            IQueryable<PersonaVinculacion> listado =
                from pd in _entities
                where pd.Id == id
                select pd;

            return await listado.ToListAsync();
        }
    }
}
