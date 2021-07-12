using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDireccionService
    {
        Task AddPersonaDireccion(PersonaDireccion personaDireccion);
        void DeletePersonasDireccionesByIdPersona(int idPersona);
        void DeletePersonaDirecccionByIds(int idPersona, int numero);
        Task<IEnumerable<PersonaDireccion>> GetPersonasDirecciones();
        void UpdatePersonaDireccion(PersonaDireccion personaDireccion);
        Task<IEnumerable<PersonaDireccion>> GetPersonasDireccionesByIdPersona(int idPersona);
    }
}
