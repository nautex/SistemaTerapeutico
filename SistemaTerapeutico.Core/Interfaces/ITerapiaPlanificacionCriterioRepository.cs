using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanificacionCriterioRepository : IBaseRepositoryThreeIds<TerapiaPlanificacionCriterio>
    {
        void DeleteTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo);
        Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia);
        Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo);
    }
}
