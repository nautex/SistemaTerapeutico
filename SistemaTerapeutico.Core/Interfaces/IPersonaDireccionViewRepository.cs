using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDireccionViewRepository : IBaseRepositoryView<PersonaDireccionView>
    {
        Task<IEnumerable<PersonaDireccionView>> GetPersonasDireccionesViewByIdPersona(int idPersona);
    }
}
