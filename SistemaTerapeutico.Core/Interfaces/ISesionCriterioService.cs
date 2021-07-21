using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionCriterioService
    {
        IEnumerable<SesionCriterio> GetSesionesCriterios();
        Task<SesionCriterio> GetSesionCriterioById(int idSesionCriterio);
        Task<int> AddSesionCriterio(SesionCriterio SesionCriterio);
        void UpdateSesionCriterio(SesionCriterio SesionCriterio);
        Task DeleteSesionCriterio(int idSesionCriterio);
        Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion);
    }
}
