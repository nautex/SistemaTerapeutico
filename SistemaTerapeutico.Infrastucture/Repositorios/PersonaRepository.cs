using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaRepository : BaseEntityRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(SISDETContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre)
        {
            var list = await _entities.Where(x => x.Nombres.Contains(nombre)).ToListAsync();

            return list;
        }
        public async Task<IEnumerable<Lista>> GetPersonsByTypeAndName(int idType, string name)
        {
            var query = from f in _context.PersonaNaturalView
                        where f.IdTipoPersona == idType
                        select new Lista { Id = f.Id, Descripcion = f.Nombres };

            return await query.OrderBy(x => x.Descripcion).ToListAsync();
        }
    }
}
