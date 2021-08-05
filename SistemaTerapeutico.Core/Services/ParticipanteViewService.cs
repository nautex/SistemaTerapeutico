using System.Collections.Generic;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class ParticipanteViewService : IParticipanteViewService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParticipanteViewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ParticipanteView> GetParticipantesView()
        {
            return _unitOfWork.ParticipanteViewRepository.GetAll();
        }
    }
}
