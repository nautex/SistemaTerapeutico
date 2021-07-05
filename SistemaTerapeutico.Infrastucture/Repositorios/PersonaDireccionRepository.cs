using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDireccionRepository : BaseRepository<PersonaDireccion>, IPersonaDireccionRepository
    {
        public PersonaDireccionRepository(SISDETContext _context) : base(_context)
        {

        }
    }
}
