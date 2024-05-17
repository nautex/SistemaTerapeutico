using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioRepository : IBaseEntityTwoIdsRepository<SesionCriterio>
    {
        Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion);
    }
}
