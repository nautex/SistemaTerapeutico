using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionRepository : IBaseEntityRepository<Sesion>
    {
        Task<IEnumerable<Sesion>> GetSesionesByIdTerapia(int idTerapia);
        Task<IEnumerable<Sesion>> GetSesionesByIdPeriodoTerapia(int idPeriodoTerapia);
    }
}
