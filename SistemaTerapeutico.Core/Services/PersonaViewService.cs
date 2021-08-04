using System.Collections.Generic;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaViewService : IPersonaViewService
    {
        private IUnitOfWork _unitOfWork;
        public PersonaViewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<PersonaView> GetPersonasView()
        {
            return _unitOfWork.PersonaViewRepository.GetAll();
        }
    }
}
