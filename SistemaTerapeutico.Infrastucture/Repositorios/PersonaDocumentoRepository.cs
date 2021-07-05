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
    }
}
