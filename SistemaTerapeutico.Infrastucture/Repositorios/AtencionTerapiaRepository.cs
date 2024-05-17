using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AtencionTerapiaRepository : BaseEntityTwoIdsRepository<AtencionTerapia>, IAtencionTerapiaRepository
    {
        public AtencionTerapiaRepository(SISDETContext context) : base(context)
        {

        }
    }
}
