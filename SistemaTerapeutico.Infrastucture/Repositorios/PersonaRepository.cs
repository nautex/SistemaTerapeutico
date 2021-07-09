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
        public async Task<Persona> GetPersonaByNumeroDocumento(string numeroDocumento)
        {
            var Persona = from p in _context.Persona
                          join pd in _context.PersonaDocumento on p.Id equals pd.Id
                          where pd.Numero == numeroDocumento
                          select p;

            return await Persona.FirstOrDefaultAsync();
        }

    }
}
