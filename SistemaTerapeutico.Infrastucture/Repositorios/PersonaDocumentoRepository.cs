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
        public async Task<PersonaDocumento> GetByIds(int id, int idTipoDocumento)
        {
            return await _entities.Where(x => x.Id == id && x.IdTipoDocumento == idTipoDocumento).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PersonaDocumento>> GetsById(int id)
        {
            return await _entities.Where(x => x.Id == id).ToListAsync();
        }
        public async Task DeletesById(int id)
        {
            IEnumerable<PersonaDocumento> list = await GetsById(id);

            _context.RemoveRange(list);
        }
        public async Task DeleteByIds(int id, int idTipoDocumento)
        {
            PersonaDocumento list = await GetByIds(id, idTipoDocumento);

            _context.Remove(list);
        }
        public async Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero)
        {
            var list = await _entities.Where(x => x.IdTipoDocumento == idTipoDocumento && x.Numero == numero).ToListAsync();

            return list;
        }
    }
}
