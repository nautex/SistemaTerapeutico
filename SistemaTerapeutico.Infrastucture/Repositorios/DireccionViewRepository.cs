using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class DireccionViewRepository : BaseRepositoryView<DireccionView>, IDireccionViewRepository
    {
        public DireccionViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
