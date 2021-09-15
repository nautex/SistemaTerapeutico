using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDocumentoRepository : BaseRepositoryTwoIds<PersonaDocumento>, IPersonaDocumentoRepository
    {
        public PersonaDocumentoRepository(SISDETContext _context) : base(_context)
        {

        }
        public async Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numeroDocumento)
        {
            var list = await _entities.Where(x => x.IdTipoDocumento == idTipoDocumento && x.NumeroDocumento == numeroDocumento).ToListAsync();

            return list;
        }
    }
}
