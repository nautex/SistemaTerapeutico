using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoRepository : IBaseRepository<Periodo>
    {
        Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo);
    }
}
