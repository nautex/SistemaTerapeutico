using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISesionService
    {
        IEnumerable<Sesion> GetSesiones();
        Task<Sesion> GetSesionById(int idSesion);
        Task<int> AddSesion(Sesion Sesion);
        void UpdateSesion(Sesion Sesion);
        Task DeleteSesion(int idSesion);
        Task<SesionView> GetSesionView(int idSesion);
        IEnumerable<SesionResumenView> GetsSesionResumenView(int idTerapeuta, string participante, int idPeriodo, DateTime? fechaInicio, DateTime? fechaFin, int idEstado);
        Task<int> AddUpdateSessionWithDetails(SesionViewDto sesionDto);
        Task<IEnumerable<SesionTerapeutaView>> GetsSesionTerapeutaView(int idSesion);
        Task DeleteSesionTerapeuta(int idSesion, int numero);
        Task<IEnumerable<SesionCriterioView>> GetsSesionCriterioView(int idSesion);
        Task DeleteSesionCriterio(int idSesion, int numero);
        Task AnnulSesion(int idSesion);
        Task ActiveSesion(int idSesion);
    }
}
