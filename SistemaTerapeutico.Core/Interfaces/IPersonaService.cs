using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
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
        Task<PersonaResponseDto> AddPersonaNaturalDatosCompletos(PersonaNaturalDatosCompletosDto personaDto);
        Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre);
        IEnumerable<PersonaResumenView> GetPersonasResumenView();
        Task<PersonaNatural> GetPersonaNaturalById(int idPersona);
        Task AddPersonaNatural(PersonaNatural personaNatural);
        void UpdatePersonaNatural(PersonaNatural personaNatural);
        Task DeletePersonaNatural(int idPersona);
        Task<PersonaNaturalView> GetPersonaNaturalViewById(int idPersona);
        Task<IEnumerable<PersonaDocumentoView>> GetPersonasDocumentosViewById(int idPersona);
    }
}