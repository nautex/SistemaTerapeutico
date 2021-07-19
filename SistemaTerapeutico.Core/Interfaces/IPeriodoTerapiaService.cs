using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoTerapiaService
    {
        IEnumerable<PeriodoTerapia> GetPeriodosTerapias();
        Task<PeriodoTerapia> GetPeriodoTerapiaById(int idPeriodoTerapia);
        Task<int> AddPeriodoTerapia(PeriodoTerapia periodoTerapia);
        void UpdatePeriodoTerapia(PeriodoTerapia periodoTerapia);
        Task DeletePeriodoTerapia(int idPeriodoTerapia);
        Task<IEnumerable<PeriodoTerapia>> GetPeriodosTerapiasByIdTipo(int idTipo);
    }
}
