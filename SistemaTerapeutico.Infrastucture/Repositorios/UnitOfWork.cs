﻿using System.Threading.Tasks;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SISDETContext _context;
        private readonly IPersonaRepository _personaRepository;
        private readonly IPersonaDocumentoRepository _personaDocumentoRepository;
        private readonly IPersonaVinculacionRepository _personaVinculacionRepository;
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IPersonaDireccionRepository _personaDireccionRepository;
        private readonly IPersonaNaturalRepository _personaNaturalRepository;
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly ICatalogoRepository _catalogoRepository;
        private readonly IDireccionRepository _direccionRepository;
        private readonly IParticipanteRepository _participanteRepository;
        private readonly IAtencionRepository _atencionRepository;
        private readonly ITerapiaRepository _terapiaRepository;
        private readonly ITerapiaTerapeutaRepository _terapiaTerapeutaRepository;
        private readonly IPeriodoRepository _periodoTerapiaRepository;
        private readonly ISesionRepository _sesionRepository;
        private readonly ISesionCriterioRepository _sesionCriterioRepository;
        private readonly ISesionCriterioActividadRepository _sesionCriterioActividadRepository;
        private readonly ITerapiaPeriodoRepository _terapiaPeriodoRepository;
        private readonly ITerapiaPlanificacionRepository _terapiaPlanificacionRepository;
        private readonly ITerapiaPlanificacionCriterioRepository _terapiaPlanificacionCriterioRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPersonaResumenViewRepository _personaResumenViewRepository;
        private readonly IParticipanteResumenViewRepository _participanteResumenViewRepository;
        private readonly IAtencionTerapiaRepository _atencionTerapiaRepository;
        private readonly IPersonaNaturalViewRepository _personaNaturalViewRepository;
        private readonly IUbigeoViewRepository _ubigeoViewRepository;
        private readonly IPersonaDocumentoViewRepository _personaDocumentoViewRepository;
        private readonly IPersonaContactoViewRepository _personaContactoViewRepository;
        private readonly IPersonaDireccionViewRepository _personaDireccionViewRepository;
        private readonly IDireccionViewRepository _direccionViewRepository;
        private readonly IPersonaVinculacionViewRepository _personaVinculacionViewRepository;
        private readonly IPersonaResumenBasicoViewRepository _personaResumenBasicoViewRepository;
        private readonly IParticipanteAlergiaRepository _participanteAlergiaRepository;
        private readonly IParticipanteAlergiaViewRepository _participanteAlergiaViewRepository;
        private readonly IParticipantePersonaAutorizadaRepository _participantePersonaAutorizadaRepository;
        private readonly IParticipantePersonaAutorizadaViewRepository _participantePersonaAutorizadaViewRepository;
        private readonly IParticipanteViewRepository _participanteViewRepository;
        private readonly ITerapiaViewRepository _terapiaViewRepository;
        private readonly ITerapiaHorarioRepository _terapiaHorarioRepository;
        private readonly ITerapiaHorarioViewRepository _terapiaHorarioViewRepository;
        private readonly ITerapiaTerapeutaViewRepository _terapiaTerapeutaViewRepository;
        private readonly ITerapiaResumenViewRepository _terapiaResumenViewRepository;
        private readonly ITerapiaParticipanteRepository _terapiaParticipanteRepository;
        private readonly ITerapiaParticipanteViewRepository _terapiaParticipanteViewRepository;
        private readonly ILocalViewRepository _localViewRepository;
        private readonly ISalonViewRepository _salonViewRepository;
        private readonly ITarifaViewRepository _tarifaViewRepository;
        private readonly IServicioRepository _servicioRepository;
        public UnitOfWork(SISDETContext context)
        {
            _context = context;
        }
        public IPersonaRepository PersonaRepository => _personaRepository ?? new PersonaRepository(_context);
        public IPersonaVinculacionRepository PersonaVinculacionRepository => _personaVinculacionRepository ?? new PersonaVinculacionRepository(_context);
        public IPersonaContactoRepository PersonaContactoRepository => _personaContactoRepository ?? new PersonaContactoRepository(_context);
        public IPersonaDireccionRepository PersonaDireccionRepository => _personaDireccionRepository ?? new PersonaDireccionRepository(_context);
        public IPersonaNaturalRepository PersonaNaturalRepository => _personaNaturalRepository ?? new PersonaNaturalRepository(_context);
        public IPersonaDocumentoRepository PersonaDocumentoRepository => _personaDocumentoRepository ?? new PersonaDocumentoRepository(_context);
        public ICatalogoRepository CatalogoRepository => _catalogoRepository ?? new CatalogoRepository(_context);
        public IDireccionRepository DireccionRepository => _direccionRepository ?? new DireccionRepository(_context);
        public IParticipanteRepository ParticipanteRepository => _participanteRepository ?? new ParticipanteRepository(_context);
        public IAtencionRepository AtencionRepository => _atencionRepository ?? new AtencionRepository(_context);
        public ITerapiaRepository TerapiaRepository => _terapiaRepository ?? new TerapiaRepository(_context);
        public ITerapiaTerapeutaRepository TerapiaTerapeutaRepository => _terapiaTerapeutaRepository ?? new TerapiaTerapeutaRepository(_context);
        public IPeriodoRepository PeriodoRepository => _periodoTerapiaRepository ?? new PeriodoRepository(_context);
        public ISesionRepository SesionRepository => _sesionRepository ?? new SesionRepository(_context);
        public ISesionCriterioRepository SesionCriterioRepository => _sesionCriterioRepository ?? new SesionCriterioRepository(_context);
        public ISesionCriterioActividadRepository SesionCriterioActividadRepository => _sesionCriterioActividadRepository ?? new SesionCriterioActividadRepository(_context);
        public ITerapiaPeriodoRepository TerapiaPeriodoRepository => _terapiaPeriodoRepository ?? new TerapiaPeriodoRepository(_context);
        public ITerapiaPlanificacionRepository TerapiaPlanificacionRepository => _terapiaPlanificacionRepository ?? new TerapiaPlanificacionRepository(_context);
        public ITerapiaPlanificacionCriterioRepository TerapiaPlanificacionCriterioRepository => _terapiaPlanificacionCriterioRepository ?? new TerapiaPlanificacionCriterioRepository(_context);
        public IUsuarioRepository UsuarioRepository => _usuarioRepository ?? new UsuarioRepository(_context);
        public IPersonaResumenViewRepository PersonaResumenViewRepository => _personaResumenViewRepository ?? new PersonaResumenViewRepository(_context);
        public IParticipanteResumenViewRepository ParticipanteResumenViewRepository => _participanteResumenViewRepository ?? new ParticipanteResumenViewRepository(_context);
        public IAtencionTerapiaRepository AtencionTerapiaRepository => _atencionTerapiaRepository ?? new AtencionTerapiaRepository(_context);
        public IPersonaNaturalViewRepository PersonaNaturalViewRepository => _personaNaturalViewRepository ?? new PersonaNaturalViewRepository(_context);
        public IUbigeoViewRepository UbigeoViewRepository => _ubigeoViewRepository ?? new UbigeoViewRepository(_context);
        public IPersonaDocumentoViewRepository PersonaDocumentoViewRepository => _personaDocumentoViewRepository ?? new PersonaDocumentoViewRepository(_context);
        public IPersonaContactoViewRepository PersonaContactoViewRepository => _personaContactoViewRepository ?? new PersonaContactoViewRepository(_context);
        public IPersonaDireccionViewRepository PersonaDireccionViewRepository => _personaDireccionViewRepository ?? new PersonaDireccionViewRepository(_context);
        public IDireccionViewRepository DireccionViewRepository => _direccionViewRepository ?? new DireccionViewRepository(_context);
        public IPersonaVinculacionViewRepository PersonaVinculacionViewRepository => _personaVinculacionViewRepository ?? new PersonaVinculacionViewRepository(_context);
        public IPersonaResumenBasicoViewRepository PersonaResumenBasicoViewRepository => _personaResumenBasicoViewRepository ?? new PersonaResumenBasicoViewRepository(_context);
        public IParticipanteAlergiaRepository ParticipanteAlergiaRepository => _participanteAlergiaRepository ?? new ParticipanteAlergiaRepository(_context);
        public IParticipanteAlergiaViewRepository ParticipanteAlergiaViewRepository => _participanteAlergiaViewRepository ?? new ParticipanteAlergiaViewRepository(_context);
        public IParticipantePersonaAutorizadaRepository ParticipantePersonaAutorizadaRepository => _participantePersonaAutorizadaRepository ?? new ParticipantePersonaAutorizadaRepository(_context);
        public IParticipantePersonaAutorizadaViewRepository ParticipantePersonaAutorizadaViewRepository => _participantePersonaAutorizadaViewRepository ?? new ParticipantePersonaAutorizadaViewRepository(_context);
        public IParticipanteViewRepository ParticipanteViewRepository => _participanteViewRepository ?? new ParticipanteViewRepository(_context);
        public ITerapiaViewRepository TerapiaViewRepository => _terapiaViewRepository ?? new TerapiaViewRepository(_context);
        public ITerapiaHorarioRepository TerapiaHorarioRepository => _terapiaHorarioRepository ?? new TerapiaHorarioRepository(_context);
        public ITerapiaHorarioViewRepository TerapiaHorarioViewRepository => _terapiaHorarioViewRepository ?? new TerapiaHorarioViewRepository(_context);
        public ITerapiaTerapeutaViewRepository TerapiaTerapeutaViewRepository => _terapiaTerapeutaViewRepository ?? new TerapiaTerapeutaViewRepository(_context);
        public ITerapiaResumenViewRepository TerapiaResumenViewRepository => _terapiaResumenViewRepository ?? new TerapiaResumenViewRepository(_context);
        public ITerapiaParticipanteRepository TerapiaParticipanteRepository => _terapiaParticipanteRepository ?? new TerapiaParticipanteRepository(_context);
        public ITerapiaParticipanteViewRepository TerapiaParticipanteViewRepository => _terapiaParticipanteViewRepository ?? new TerapiaParticipanteViewRepository(_context);
        public ILocalViewRepository LocalViewRepository => _localViewRepository ?? new LocalViewRepository(_context);
        public ISalonViewRepository SalonViewRepository => _salonViewRepository ?? new SalonViewRepository(_context);
        public ITarifaViewRepository TarifaViewRepository => _tarifaViewRepository ?? new TarifaViewRepository(_context);
        public IServicioRepository ServicioRepository => _servicioRepository ?? new ServicioRepository(_context);
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
