using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class TerapiaTerapeutaService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public TerapiaTerapeutaService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddTerapiaTerapeuta(TerapiaTerapeuta terapiaTerapeuta)
        {
            await _context.AddAsync(terapiaTerapeuta);
            _context.SaveChanges();
        }

        public async void DeleteTerapiasTerapeutasByIdAtencion(int idAtencion)
        {
            await _context.DeletesById<TerapiaTerapeuta>(idAtencion);
            _context.SaveChanges();
        }

        public async void DeleteTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta)
        {
            await _context.DeleteByIds<TerapiaTerapeuta>(idAtencion, idTerapeuta);
            _context.SaveChanges();
        }

        public IEnumerable<TerapiaTerapeuta> GetTerapiasTerapeutas()
        {
            return _context.GetAll<TerapiaTerapeuta>();
        }

        public async Task<IEnumerable<TerapiaTerapeuta>> GetTerapiasTerapeutasByIdAtencion(int idAtencion)
        {
            return await _context.GetsById<TerapiaTerapeuta>(idAtencion);
        }

        public async Task<TerapiaTerapeuta> GetTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta)
        {
            return await _context.GetByIds<TerapiaTerapeuta>(idAtencion, idTerapeuta);
        }

        public void UpdateTerapiaTerapeuta(TerapiaTerapeuta terapiaTerapeuta)
        {
            _context.Update(terapiaTerapeuta);
            _context.SaveChanges();
        }
    }
}
