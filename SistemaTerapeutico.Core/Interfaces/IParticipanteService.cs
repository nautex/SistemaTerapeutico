using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IParticipanteService
    {
        Task AddParticipante(Participante participante);
        Task<Participante> GetParticipanteById(int idParticipante);
    }
}
