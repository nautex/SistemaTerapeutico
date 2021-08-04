using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaViewRepository : BaseRepositoryView<PersonaView>, IPersonaViewRepository
    {

        public PersonaViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
