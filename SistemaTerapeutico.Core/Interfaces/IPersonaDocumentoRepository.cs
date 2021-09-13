using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDocumentoRepository : IBaseRepositoryTwoIds<PersonaDocumento>
    {
        Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numeroDocumento);
    }
}
