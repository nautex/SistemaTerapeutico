using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaNaturalService
    {
        IEnumerable<PersonaNatural> GetPersonasNaturales();
        Task<PersonaNatural> GetPersonaNaturalById(int idPersona);
        Task AddPersonaNatural(PersonaNatural personaNatural);
        void UpdatePersonaNatural(PersonaNatural personaNatural);
        Task DeletePersonaNatural(int idPersona);
    }
}
