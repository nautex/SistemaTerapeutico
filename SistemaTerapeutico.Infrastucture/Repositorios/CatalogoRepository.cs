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
    }
}
