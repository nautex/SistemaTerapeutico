using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionService
    {
        IEnumerable<Sesion> GetSesiones();
        Task<Sesion> GetSesionById(int idSesion);
        Task<int> AddSesion(Sesion Sesion);
        void UpdateSesion(Sesion Sesion);
        Task DeleteSesion(int idSesion);
        Task<IEnumerable<Sesion>> GetSesionesByIdTerapia(int idTerapia);
        Task<IEnumerable<Sesion>> GetSesionesByIdPeriodoTerapia(int idPeriodoTerapia);
    }
}
