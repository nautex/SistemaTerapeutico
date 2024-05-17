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
        IEnumerable<ParticipanteResumenView> GetsParticipantesResumenView();
        IEnumerable<ParticipanteResumenView> GetsParticipantesResumenViewByMemberOrRelative(string member, string relative);
        Task<IEnumerable<ParticipanteAlergiaView>> GetsParticipanteAlergiaViewById(int idParticipante);
        Task<IEnumerable<ParticipantePersonaAutorizadaView>> GetsParticipantePersonaAutorizadaViewById(int idParticipante);
        Task<int> AddUpdateParticipanteWithDetails(Participante participante);
        Task<ParticipanteView> GetParticipanteViewById(int idParticipante);
        Task DeleteParticipanteAlergia(int idParticipante, int numero);
        Task DeleteParticipantePersonaAutorizada(int idParticipante, int numero);
    }
}
