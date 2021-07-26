using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioService
    {
        IEnumerable<SesionCriterio> GetSesionesCriterios();
        Task<SesionCriterio> GetSesionCriterioByIds(int idSesion, int idObjetivoCriterio);
        Task<int> AddSesionCriterio(SesionCriterio SesionCriterio);
        void UpdateSesionCriterio(SesionCriterio SesionCriterio);
        Task DeleteSesionCriterioByIds(int idSesion, int idObjetivoCriterio);
        Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion);
    }
}
