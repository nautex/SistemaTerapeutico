using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaResumenBasicoViewRepository : BaseRepository<PersonaResumenBasicoView>, IPersonaResumenBasicoViewRepository
    {
        public PersonaResumenBasicoViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
