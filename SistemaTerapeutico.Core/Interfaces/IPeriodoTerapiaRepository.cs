using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoTerapiaRepository : IBaseRepository<Periodo>
    {
        Task<IEnumerable<Periodo>> GetTerapiasPeriodosByIdTerapia(int idTipo);
    }
}
