using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionRepository : IBaseRepository<PersonaVinculacion>
    {
        Task<PersonaVinculacion> GetByIds(int id, int idPersonaVinculo);
        Task<IEnumerable<PersonaVinculacion>> GetsById(int id);
        Task DeletesById(int id);
        Task DeleteByIds(int id, int idPersonaVinculo);
    }
}
