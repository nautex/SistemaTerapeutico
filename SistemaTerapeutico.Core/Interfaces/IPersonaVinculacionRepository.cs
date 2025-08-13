using SistemaTerapeutico.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionRepository : IBaseEntityTwoIdsRepository<PersonaVinculacion>
    {
        Task<IEnumerable<PersonaVinculacion>> GetsPersonaVinculacionTwoPersons(int idPersona, int idPersonaVinculo);
    }
}
