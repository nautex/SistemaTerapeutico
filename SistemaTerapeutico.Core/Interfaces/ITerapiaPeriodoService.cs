using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPeriodoService
    {
        Task AddTerapiaPeriodo(TerapiaPeriodo terapiaPeriodo);
        void DeletePersonaDirecccionByIds(int idTerapia, int idPeriodo);
        Task<TerapiaPeriodo> GetTerapiaPeriodoByIds(int idTerapia, int idPeriodo);
        IEnumerable<TerapiaPeriodo> GetTerapiasPeriodos();
        void UpdateTerapiaPeriodo(TerapiaPeriodo terapiaPeriodo);
        Task<IEnumerable<TerapiaPeriodo>> GetTerapiasPeriodosByIdTerapia(int idTerapia);
    }
}
