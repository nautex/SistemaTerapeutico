using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoService
    {
        IEnumerable<Periodo> GetPeriodos();
        Task<Periodo> GetPeriodoById(int idPeriodo);
        Task<int> AddPeriodo(Periodo periodo);
        void UpdatePeriodo(Periodo periodo);
        Task DeletePeriodo(int idPeriodo);
        Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo);
    }
}
