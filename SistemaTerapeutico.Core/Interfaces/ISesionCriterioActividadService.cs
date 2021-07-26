using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioActividadService
    {
        Task AddSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad);
        void DeleteSesionesCriteriosActividadesByIdSesion(int idSesion);
        void DeleteSesionCriterioActividadByIds(int idSesion, int idObjetivoCriterio, int idActividad);
        Task<SesionCriterioActividad> GetSesionCriterioActividadByIds(int idSesion, int idObjetivoCriterio, int idActividad);
        IEnumerable<SesionCriterioActividad> GetSesionesCriteriosActividades();
        void UpdateSesionCriterioActividad(SesionCriterioActividad sesionCriterioActividad);
        Task<IEnumerable<SesionCriterioActividad>> GetSesionesCriteriosActividadesByidSesion(int idSesion);
    }
}
