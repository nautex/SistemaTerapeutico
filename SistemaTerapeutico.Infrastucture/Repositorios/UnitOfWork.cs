﻿using System.Threading.Tasks;
using SistemaTerapeutico.Core.Interfaces;
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