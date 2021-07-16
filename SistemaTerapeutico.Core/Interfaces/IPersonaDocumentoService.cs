using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDocumentoService
    {
        Task AddPersonaDocumento(PersonaDocumento personaDocumento);
        void DeletePersonasDocumentosByIdPersona(int idPersona);
        void DeletePersonaDocumentoByIds(int idPersona, int idTipoDocumento);
        IEnumerable<PersonaDocumento> GetPersonasDocumentos();
        void UpdatePersonaDocumento(PersonaDocumento personaDocumento);
        Task<PersonaDocumento> GetPersonaDocumentoByIds(int idPersona, int idTipoDocumento);
        Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByIdPersona(int idPersona);
        Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero);
    }
}
