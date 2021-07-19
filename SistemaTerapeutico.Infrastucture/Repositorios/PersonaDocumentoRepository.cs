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
        public async Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero)
        {
            var list = await _entities.Where(x => x.IdTwo == idTipoDocumento && x.Numero == numero).ToListAsync();

            return list;
        }
    }
}
