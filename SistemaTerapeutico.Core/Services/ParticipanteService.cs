using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task AddParticipante(Participante participante)
        {
            return _unitOfWork.ParticipanteRepository.Add(participante);
        }
    }
}
