using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class CatalogoService
    {
        private readonly SISDETContext _context;
        public CatalogoService(SISDETContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Catalogo>> GetCatalogosByIdPadre(int idPadre)
        {
            return await _context.Catalogo.Where(x => x.IdPadre == idPadre).OrderBy(x => x.Orden).ToListAsync();
        }
        public async Task<IEnumerable<Lista>> GetCatalogosByIdPadreInLista(int idPadre)
        {
            var query = from f in _context.Catalogo
                        where f.IdPadre == idPadre
                        select new Lista { Id = f.Id, Descripcion = f.Descripcion, Orden = f.Orden };

            return await query.OrderBy(x => x.Orden).ToListAsync();
        }
        public async Task<Catalogo> GetCatalogo(int id)
        {
            return await _context.GetById<Catalogo>(id);
        }
    }
}
