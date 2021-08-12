using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteResumenViewRepository : BaseRepositoryView<ParticipanteResumenView>, IParticipanteViewRepository
    {
        public ParticipanteResumenViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
