using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanificacionCriterioService
    {
        Task AddTerapiaPlanificacionCriterio(TerapiaPlanificacionCriterio terapiaPlanificacionCriterio);
        void DeleteTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia);
        void DeleteTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo);
        void DeleteTerapiaPlanificacionCriterioByIds(int idTerapia, int idPeriodo, int idObjetivoCriterio);
        Task<TerapiaPlanificacionCriterio> GetTerapiaPlanificacionCriterioByIds(int idTerapia, int idPeriodo, int idObjetivoCriterio);
        IEnumerable<TerapiaPlanificacionCriterio> GetTerapiasPlanificacionesCriterios();
        void UpdateTerapiaPlanificacionCriterio(TerapiaPlanificacionCriterio terapiaPlanificacionCriterio);
        Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia);
        Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo);
    }
}
