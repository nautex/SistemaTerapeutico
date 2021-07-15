using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDocumentoRepository : BaseRepository<PersonaDocumento>, IPersonaDocumentoRepository
    {
        public PersonaDocumentoRepository(SISDETContext _context) : base(_context)
        {

        }
        public async Task<IEnumerable<PersonaDocumento>> GetsById(int id)
        {
            IQueryable<PersonaDocumento> listado =
                from pd in _entities
                where pd.Id == id
                select pd;

            return await listado.ToListAsync();
        }
        public async Task DeletesById(int id)
        {
            IEnumerable<PersonaDocumento> entities = await GetsById(id);

            _context.RemoveRange(entities);
        }
        public async Task<PersonaDocumento> GetByIds(int id, int idTipoDocumento)
        {
            IQueryable<PersonaDocumento> listado =
                from pd in _entities
                where pd.Id == id && pd.IdTipoDocumento == idTipoDocumento
                select pd;

            return await listado.FirstOrDefaultAsync();
        }
        public async Task DeleteByIds(int id, int idTipoDocumento)
        {
            PersonaDocumento entity = await GetByIds(id, idTipoDocumento);

            _context.Remove(entity);
        }
        public async Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero)
        {
            IQueryable<PersonaDocumento> listado =
                from pd in _entities
                where pd.IdTipoDocumento == idTipoDocumento && pd.Numero == numero
                select pd;

            return await listado.ToListAsync();
        }
    }
}
