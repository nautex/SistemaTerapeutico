using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaAntecedenteViewRepository : BaseRepositoryView<PersonaAntecedenteView>, IPersonaAntecedenteViewRepository
    {
        public PersonaAntecedenteViewRepository(SISDETContext context) : base(context)
        {
        }
        public async Task<IEnumerable<PersonaAntecedenteView>> GetPersonasAntecedenteViewByIdPersona(int idPersona)
        {
            return await _entities.Where(x => x.IdPersona == idPersona).ToListAsync();
        }
    }
}
