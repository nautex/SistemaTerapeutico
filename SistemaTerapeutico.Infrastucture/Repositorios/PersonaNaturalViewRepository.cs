using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaNaturalViewRepository : BaseRepositoryView<PersonaNaturalView>, IPersonaNaturalViewRepository
    {
        public PersonaNaturalViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
