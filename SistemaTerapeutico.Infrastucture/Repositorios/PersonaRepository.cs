using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaRepository : BaseRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(SISDETContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Persona>> GetPersonasByNombre(string nombre)
        {
            var list = await _entities.Where(x => x.Nombres.Contains(nombre)).ToListAsync();

            return list;
        }
    }
}
