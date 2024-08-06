using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;

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
        IEnumerable<PeriodoView> GetsPeriodoView(int idTipoTerapia, int idEstadoApertura, int mesesHaciaAtras, int idEstado);
        Task AnnulPeriodo(int idPeriodo);
        Task ActivePeriodo(int idPeriodo);
        Task<PeriodoView> GetPeriodoView(int idPeriodo);
        Task<int> AddUpdatePeriodo(PeriodoViewDto periodoViewDto);
    }
}
