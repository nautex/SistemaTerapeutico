using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IParticipanteService
    {
        Task AddParticipante(Participante participante);
        Task<Participante> GetParticipanteById(int idParticipante);
        IEnumerable<ParticipanteResumenView> GetParticipantesView();
    }
}
