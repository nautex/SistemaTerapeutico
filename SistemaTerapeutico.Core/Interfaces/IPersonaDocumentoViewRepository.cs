using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDocumentoViewRepository : IBaseRepositoryView<PersonaDocumentoView>
    {
        Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosByIdPersona(int idPersona);
    }
}
