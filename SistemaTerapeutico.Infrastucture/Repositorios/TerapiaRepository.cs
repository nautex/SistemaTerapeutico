using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaRepository : BaseRepository<Terapia>, ITerapiaRepository
    {
        public TerapiaRepository(SISDETContext context) : base(context)
        {

        }

    }
}
