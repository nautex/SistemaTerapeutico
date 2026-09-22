using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PuntuacionService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PuntuacionService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<int> AddPuntuacionGrupo(PuntuacionGrupo entity)
        {
            return _context.AddReturnId(entity);
        }

        public async Task DeletePuntuacionGrupo(int idPuntuacionGrupo)
        {
            await _context.Delete<PuntuacionGrupo>(idPuntuacionGrupo);
            _context.SaveChanges();
        }

        public async Task<PuntuacionGrupo> GetPuntuacionGrupo(int idPuntuacionGrupo)
        {
            return await _context.GetById<PuntuacionGrupo>(idPuntuacionGrupo);
        }

        public IEnumerable<PuntuacionGrupo> GetsPuntuacionGrupo()
        {
            return _context.GetAll<PuntuacionGrupo>();
        }
        public void UpdatePuntuacionGrupo(PuntuacionGrupo sesion)
        {
            _context.Update(sesion);
            _context.SaveChanges();
        }
    }
}
