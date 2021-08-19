using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class CatalogoRepository : BaseRepository<Catalogo>, ICatalogoRepository
    {
        public CatalogoRepository(SISDETContext _context) : base(_context)
        {

        }
        public async Task<IEnumerable<Catalogo>> GetCatalogosByIdPadre(int idPadre)
        {
            return await _entities.Where(x => x.IdPadre == idPadre).OrderBy(x => x.Orden).ToListAsync();
        }
        public async Task<IEnumerable<Lista>> GetCatalogosByIdPadreInLista(int idPadre)
        {
            var query = from f in _context.Catalogo
                        where f.IdPadre == idPadre
                        select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return await query.OrderBy(x => x.Descripcion).ToListAsync();
        }
    }
}
