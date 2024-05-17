using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaTerapeutaRepository : BaseEntity2IdsRepository<TerapiaTerapeuta>, ITerapiaTerapeutaRepository
    {
        public TerapiaTerapeutaRepository(SISDETContext context) : base(context)
        {

        }
    }
}
