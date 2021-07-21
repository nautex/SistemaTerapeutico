using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioRepository : IBaseRepository<SesionCriterio>
    {
        Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion);
    }
}
