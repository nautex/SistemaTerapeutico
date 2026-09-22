using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class UbigeoViewService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public UbigeoViewService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Lista>> GetDepartamentosByIdPais(int idPais)
        {
            var list = from f in _context.UbigeoView
                       where f.IdPais == idPais
                       select new Lista { Id = f.IdDepartamento, Descripcion = f.Departamento };

            return await list.Distinct().OrderBy(x => x.Descripcion).ToListAsync();
        }

        public async Task<IEnumerable<Lista>> GetPaises()
        {
            var list = from f in _context.UbigeoView
                       select new Lista { Id = f.IdPais, Descripcion = f.Pais };

            var distinct = await list.Distinct().OrderBy(x => x.Descripcion).ToListAsync();

            return distinct;
        }

        public async Task<IEnumerable<Lista>> GetProvinciasByIdDepartamento(int idDepartamento)
        {
            var list = from f in _context.UbigeoView
                       where f.IdDepartamento == idDepartamento
                       select new Lista { Id = f.IdProvincia, Descripcion = f.Provincia };

            return await list.Distinct().OrderBy(x => x.Descripcion).ToListAsync();
        }

        public async Task<IEnumerable<Lista>> GetUbigeosByIdProvincia(int idProvincia)
        {
            var list = from f in _context.UbigeoView
                       where f.IdProvincia == idProvincia
                       select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return await list.Distinct().OrderBy(x => x.Descripcion).ToListAsync();
        }

        public async Task<UbigeoView> GetUbigeoViewById(int id)
        {
            return await _context.GetById<UbigeoView>(id);
        }
    }
}
