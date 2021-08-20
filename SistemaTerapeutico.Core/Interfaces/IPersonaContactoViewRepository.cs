using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaContactoViewRepository : IBaseRepositoryView<PersonaContactoView>
    {
        Task<IEnumerable<PersonaContactoView>> GetPersonasContactosViewByIdPersona(int idPersona);
    }
}
