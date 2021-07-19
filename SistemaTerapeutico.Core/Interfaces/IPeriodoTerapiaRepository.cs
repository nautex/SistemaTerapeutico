using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoTerapiaRepository : IBaseRepository<PeriodoTerapia>
    {
        Task<IEnumerable<PeriodoTerapia>> GetTerapiasPeriodosByIdTerapia(int idTipo);
    }
}
