using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;

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
    }
}