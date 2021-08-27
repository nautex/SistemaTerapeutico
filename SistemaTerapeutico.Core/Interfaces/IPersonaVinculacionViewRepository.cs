using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaVinculacionViewRepository : IBaseRepositoryView<PersonaVinculacionView>
    {
        Task<IEnumerable<PersonaVinculacionView>> GetPersonasVinculacionesViewByIdPersona(int idPersona);
    }
}
