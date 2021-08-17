using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDocumentoViewRepository : BaseRepositoryView<PersonaDocumentoView>, IPersonaDocumentoViewRepository
    {
        public PersonaDocumentoViewRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosById(int idPersona)
        {
            return await _entities.Where(x => x.Id == idPersona).ToListAsync();
        }
    }
}
