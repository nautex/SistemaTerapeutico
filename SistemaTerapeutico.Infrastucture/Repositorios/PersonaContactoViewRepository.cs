using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaContactoViewRepository : BaseRepositoryView<PersonaContactoView>, IPersonaContactoViewRepository
    {
        public PersonaContactoViewRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<PersonaContactoView>> GetPersonasContactosViewByIdPersona(int idPersona)
        {
            return await _entities.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
    }
}
