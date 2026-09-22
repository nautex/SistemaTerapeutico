using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaAntecedenteViewRepository : IBaseRepositoryView<PersonaAntecedenteView>
    {
        Task<IEnumerable<PersonaAntecedenteView>> GetPersonasAntecedenteViewByIdPersona(int idPersona);
    }
}
