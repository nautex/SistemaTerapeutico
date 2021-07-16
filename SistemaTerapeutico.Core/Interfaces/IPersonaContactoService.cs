using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaContactoService
    {
        Task AddPersonaContacto(PersonaContacto personaContacto);
        void DeletePersonasContactosByIdPersona(int idPersona);
        void DeletePersonaContactoByIds(int idPersona, int numero);
        IEnumerable<PersonaContacto> GetPersonasContactos();
        void UpdatePersonaContacto(PersonaContacto personaContacto);
        Task<IEnumerable<PersonaContacto>> GetPersonasContactosByIdPersona(int idPersona);
    }
}
