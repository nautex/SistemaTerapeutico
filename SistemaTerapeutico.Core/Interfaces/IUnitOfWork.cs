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
        IPeriodoRepository PeriodoRepository { get; }
        ISesionRepository SesionRepository { get; }
        ISesionCriterioRepository SesionCriterioRepository { get; }
        ISesionCriterioActividadRepository SesionCriterioActividadRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        IPersonaResumenViewRepository PersonaResumenViewRepository { get; }
        IParticipanteResumenViewRepository ParticipanteResumenViewRepository { get; }
        IAtencionTerapiaRepository AtencionTerapiaRepository { get; }
        IPersonaNaturalViewRepository PersonaNaturalViewRepository { get; }
        IUbigeoViewRepository UbigeoViewRepository { get; }
        IPersonaDocumentoViewRepository PersonaDocumentoViewRepository { get; }
        IPersonaContactoViewRepository PersonaContactoViewRepository { get; }
        IPersonaDireccionViewRepository PersonaDireccionViewRepository { get; }
        IDireccionViewRepository DireccionViewRepository { get; }
        IPersonaVinculacionViewRepository PersonaVinculacionViewRepository { get; }
        IPersonaResumenBasicoViewRepository PersonaResumenBasicoViewRepository { get; }
        IParticipanteAlergiaRepository ParticipanteAlergiaRepository { get; }
        IParticipanteAlergiaViewRepository ParticipanteAlergiaViewRepository { get; }
        IParticipantePersonaAutorizadaRepository ParticipantePersonaAutorizadaRepository { get; }
        IParticipantePersonaAutorizadaViewRepository ParticipantePersonaAutorizadaViewRepository { get; }
        IParticipanteViewRepository ParticipanteViewRepository { get; }
        ITerapiaRepository TerapiaRepository { get; }
        ITerapiaViewRepository TerapiaViewRepository { get; }
        ITerapiaTerapeutaRepository TerapiaTerapeutaRepository { get; }
        ITerapiaPeriodoRepository TerapiaPeriodoRepository { get; }
        ITerapiaPlanificacionRepository TerapiaPlanificacionRepository { get; }
        ITerapiaPlanificacionCriterioRepository TerapiaPlanificacionCriterioRepository { get; }
        ITerapiaHorarioRepository TerapiaHorarioRepository { get; }
        ITerapiaHorarioViewRepository TerapiaHorarioViewRepository { get; }
        ITerapiaTerapeutaViewRepository TerapiaTerapeutaViewRepository { get; }
        ITerapiaResumenViewRepository TerapiaResumenViewRepository { get; }
        ITerapiaParticipanteRepository TerapiaParticipanteRepository { get; }
        ITerapiaParticipanteViewRepository TerapiaParticipanteViewRepository { get; }
        ILocalViewRepository LocalViewRepository { get; }
        ISalonViewRepository SalonViewRepository { get; }
        ITarifaViewRepository TarifaViewRepository { get; }
        IServicioRepository ServicioRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
