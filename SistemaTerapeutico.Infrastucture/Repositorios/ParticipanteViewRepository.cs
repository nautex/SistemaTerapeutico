using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ParticipanteViewRepository : BaseRepositoryView<ParticipanteView>, IParticipanteViewRepository
    {
        public ParticipanteViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
