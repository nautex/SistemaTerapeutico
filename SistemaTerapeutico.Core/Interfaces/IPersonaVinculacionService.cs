using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionService
    {
        Task AddPersonaVinculacion(PersonaVinculacion personaVinculacion);
        void DeletePersonasVinculacionesByIdPersona(int idPersona);
        void DeletePersonaVinculacionByIds(int idPersona, int idPersonaVinculo);
        Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculaciones();
        void UpdatePersonaVinculacion(PersonaVinculacion personaVinculacion);
        Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionesByIdPersona(int idPersona);
    }
}
//123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100