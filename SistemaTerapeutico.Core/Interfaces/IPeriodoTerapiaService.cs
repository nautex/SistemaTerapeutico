using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPeriodoTerapiaService
    {
        IEnumerable<Periodo> GetPeriodosTerapias();
        Task<Periodo> GetPeriodoTerapiaById(int idPeriodoTerapia);
        Task<int> AddPeriodoTerapia(Periodo periodoTerapia);
        void UpdatePeriodoTerapia(Periodo periodoTerapia);
        Task DeletePeriodoTerapia(int idPeriodoTerapia);
        Task<IEnumerable<Periodo>> GetPeriodosTerapiasByIdTipo(int idTipo);
    }
}
