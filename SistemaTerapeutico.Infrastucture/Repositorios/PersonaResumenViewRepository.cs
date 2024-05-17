using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaResumenViewRepository : BaseRepository<PersonaResumenView>, IPersonaResumenViewRepository
    {

        public PersonaResumenViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
