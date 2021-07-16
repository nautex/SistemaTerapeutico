using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDocumentoRepository : IBaseRepository<PersonaDocumento>
    {
        Task<PersonaDocumento> GetByIds(int id, int idTipoDocumento);
        Task<IEnumerable<PersonaDocumento>> GetsById(int id);
        Task DeletesById(int id);
        Task DeleteByIds(int id, int idTipoDocumento);
        Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero);
    }
}
