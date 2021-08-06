using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipanteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddParticipante(Participante participante)
        {
            await _unitOfWork.ParticipanteRepository.Add(participante);
            _unitOfWork.SaveChanges();
        }
        public Task<Participante> GetParticipanteById(int idParticipante)
        {
            return _unitOfWork.ParticipanteRepository.GetById(idParticipante);
        }
        public IEnumerable<ParticipanteView> GetParticipantesView()
        {
            return _unitOfWork.ParticipanteViewRepository.GetAll();
        }
    }
}
