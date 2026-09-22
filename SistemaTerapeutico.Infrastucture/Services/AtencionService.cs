using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class AtencionService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;

        public AtencionService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddAtencion(Atencion atencion)
        {
            await _context.AddReturnId(atencion);

            return atencion.Id;
        }
        public async Task DeleteAtencion(int idAtencion)
        {
            await _context.Delete<Atencion>(idAtencion);
            _context.SaveChanges();
        }
        public Task<Atencion> GetAtencionById(int idAtencion)
        {
            return _context.GetById<Atencion>(idAtencion);
        }
        public IEnumerable<Atencion> GetAtenciones()
        {
            return _context.GetAll<Atencion>();
        }
        public void UpdateAtencion(Atencion atencion)
        {
            _context.Update(atencion);
            _context.SaveChanges();
        }
    }
}
