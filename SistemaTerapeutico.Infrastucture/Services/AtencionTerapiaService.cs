using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class AtencionTerapiaService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public AtencionTerapiaService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddAtencionTerapia(AtencionTerapia atencionTerapia)
        {
            await _context.AddAsync(atencionTerapia);
        }

        public async void DeleteAtencionesTerapiasByIdAtencion(int idAtencion)
        {
            await _context.DeletesById<AtencionTerapia>(idAtencion);
            _context.SaveChanges();
        }

        public async void DeleteAtencionTerapiaByIds(int idAtencion, int idTerapia)
        {
            await _context.DeleteByIds<AtencionTerapia>(idAtencion, idTerapia);
            _context.SaveChanges();
        }

        public IEnumerable<AtencionTerapia> GetAtencionesTerapias()
        {
            return _context.GetAll<AtencionTerapia>();
        }

        public async Task<IEnumerable<AtencionTerapia>> GetAtencionesTerapiasByIdAtencion(int idAtencion)
        {
            return await _context.AtencionTerapia.Where(x => x.Id == idAtencion).ToListAsync();
        }

        public void UpdateAtencionTerapia(AtencionTerapia atencionTerapia)
        {
            _context.Update(atencionTerapia);
            _context.SaveChanges();
        }
    }
}
