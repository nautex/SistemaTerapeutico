using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoRepository : IBaseEntityRepository<Periodo>
    {
        Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipoTerapia);
    }
}
