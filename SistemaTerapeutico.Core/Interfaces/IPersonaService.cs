using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaService
    {
        IEnumerable<Persona> GetPersonas();
        Task<Persona> GetPersonaById(int idPersona);
        Task<int> AddPersona(Persona persona);
        void UpdatePersona(Persona persona);
        Task DeletePersona(int idPersona);
        //Task<int> AddChildWithParents(PersonaNaturalDatosCompletosDto child, PersonaNaturalDatosCompletosDto mother, PersonaNaturalDatosCompletosDto dad);
        //Task<PersonaResponseDto> AddPersonaNaturalDatosCompletos(PersonaNaturalDatosCompletosDto personaDto);
        Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre);
        IEnumerable<PersonaResumenView> GetPersonasResumenView();
        Task<PersonaNatural> GetPersonaNaturalById(int idPersona);
        Task AddPersonaNatural(PersonaNatural personaNatural);
        void UpdatePersonaNatural(PersonaNatural personaNatural);
        Task DeletePersonaNatural(int idPersona);
        Task<PersonaNaturalView> GetPersonaNaturalViewById(int idPersona);
        Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosViewByIdPersona(int idPersona);
        Task<IEnumerable<PersonaContactoView>> GetPersonasContactosViewByIdPersona(int idPersona);
        Task<IEnumerable<PersonaDireccionView>> GetPersonasDireccionesViewByIdPersona(int idPersona);
        Task<IEnumerable<PersonaVinculacionView>> GetPersonasVinculacionesViewByIdPersona(int idPersona);
        IEnumerable<PersonaResumenBasicoView> GetPersonasResumenBasicoViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres);
        IEnumerable<PersonaResumenView> GetPersonasResumenViewByNumeroDocumentoYNombres(string numeroDocumento, string nombres);
        IEnumerable<Lista> GetsListPersonByTypeAndName(int idType, string name);
        Task<int> AddPersonaNaturalWithDetails(Persona persona);
        Task DeletePersonaDireccion(int idPersona, int numero);
        Task DeletePersonaDocumento(int idPersona, int numero);
        Task DeletePersonaContacto(int idPersona, int numero);
        Task DeletePersonaVinculacion(int idPersona, int numero);
    }
}