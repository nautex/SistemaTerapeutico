using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionRepository : IBaseRepository<PersonaVinculacion>
    {

        Task<IEnumerable<PersonaVinculacion>> GetsById(int id);
        Task DeletesById(int id);
        Task<PersonaVinculacion> GetByIds(int id, int idPersonaVinculo);
        Task DeleteByIds(int id, int idPersonaVinculo);
        Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionsByIdPersonaVinculo(int idPersonaVinculo);
    }
}
