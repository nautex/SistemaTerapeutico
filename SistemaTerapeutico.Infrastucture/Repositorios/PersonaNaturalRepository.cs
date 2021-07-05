using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaNaturalRepository : BaseRepository<PersonaNatural>, IPersonaNaturalRepository
    {
        public PersonaNaturalRepository(SISDETContext _context) : base(_context)
        {

        }
    }
}
