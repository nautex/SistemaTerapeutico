using System.Collections.Generic;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IParticipanteViewService
    {
        IEnumerable<ParticipanteView> GetParticipantesView();
    }
}
