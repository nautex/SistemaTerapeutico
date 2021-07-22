using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioActividadService
    {
        Task AddSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad);
        void DeleteSesionesCriteriosActividadesByIdSesionCriterio(int idSesionCriterio);
        void DeleteSesionCriterioActividadByIds(int idSesionCriterio, int idActividad);
        Task<SesionCriterioActividad> GetSesionCriterioActividadByIds(int idSesionCriterio, int idActividad);
        IEnumerable<SesionCriterioActividad> GetSesionesCriteriosActividades();
        void UpdateSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad);
        Task<IEnumerable<SesionCriterioActividad>> GetSesionesCriteriosActividadesByidSesionCriterio(int idSesionCriterio);
    }
}
