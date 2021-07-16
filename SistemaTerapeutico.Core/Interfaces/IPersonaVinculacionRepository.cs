using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionRepository : IBaseRepository<PersonaVinculacion>
    {
        void DeletesById(int id);
        void DeleteByIds(int id, int idPersonaVinculo);
    }
}
