using System;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IPersonaVinculacionRepository PersonaVinculacionRepository { get; }
        IPersonaContactoRepository PersonaContactoRepository { get; }
        IPersonaDireccionRepository PersonaDireccionRepository { get; }
        IPersonaNaturalRepository PersonaNaturalRepository { get; }
        IPersonaDocumentoRepository PersonaDocumentoRepository { get; }
        ICatalogoRepository CatalogoRepository { get; }
        IDireccionRepository DireccionRepository { get; }
        IParticipanteRepository ParticipanteRepository { get; }
        IAtencionRepository AtencionRepository { get; }
        ITerapiaRepository TerapiaRepository { get; }
        ITerapiaTerapeutaRepository TerapiaTerapeutaRepository { get; }
        IPeriodoRepository PeriodoRepository { get; }
        ISesionRepository SesionRepository { get; }
        ISesionCriterioRepository SesionCriterioRepository { get; }
        ISesionCriterioActividadRepository SesionCriterioActividadRepository { get; }
        ITerapiaPeriodoRepository TerapiaPeriodoRepository { get; }
        ITerapiaPlanificacionRepository TerapiaPlanificacionRepository { get; }
        ITerapiaPlanificacionCriterioRepository TerapiaPlanificacionCriterioRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPersonaResumenViewRepository PersonaViewRepository { get; }
        IParticipanteResumenViewRepository ParticipanteViewRepository { get; }
        IAtencionTerapiaRepository AtencionTerapiaRepository { get; }
        IPersonaNaturalViewRepository PersonaNaturalViewRepository { get; }
        IUbigeoViewRepository UbigeoViewRepository { get; }
        IPersonaDocumentoViewRepository PersonaDocumentoViewRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
