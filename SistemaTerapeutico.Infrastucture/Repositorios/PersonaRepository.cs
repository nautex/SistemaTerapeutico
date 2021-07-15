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
        public async Task<IEnumerable<Persona>> GetPersonasByNombres(string nombres)
        {
            var Personas = from p in _context.Persona
                           where p.Nombres.Contains(nombres)
                           select p;

            return await Personas.ToListAsync();
        }

    }
}
