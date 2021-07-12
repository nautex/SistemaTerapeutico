using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDireccionRepository : BaseRepositoryTwoIds<PersonaDireccion>, IPersonaDireccionRepository
    {
        public PersonaDireccionRepository(SISDETContext context) : base(context)
        {

        }
    }
}
