using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDireccionViewRepository : BaseRepositoryView<PersonaDireccionView>, IPersonaDireccionViewRepository
    {
        public PersonaDireccionViewRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<PersonaDireccionView>> GetPersonasDireccionesViewByIdPersona(int idPersona)
        {
            return await _entities.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
    }
}
