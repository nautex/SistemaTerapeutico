using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaNaturalService : IPersonaNaturalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaNaturalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<PersonaNatural> GetPersonasNaturales()
        {
            return _unitOfWork.PersonaNaturalRepository.GetAll();
        }
        public Task<PersonaNatural> GetPersonaNaturalById(int idPersona)
        {
            return _unitOfWork.PersonaNaturalRepository.GetById(idPersona);
        }
        public async Task AddPersonaNatural(PersonaNatural personaNatural)
        {
            await _unitOfWork.PersonaNaturalRepository.Add(personaNatural);
            _unitOfWork.SaveChanges();
        }
        public void UpdatePersonaNatural(PersonaNatural personaNatural)
        {
            _unitOfWork.PersonaNaturalRepository.Update(personaNatural);
            _unitOfWork.SaveChanges();
        }
        public async Task DeletePersonaNatural(int idPersona)
        {
            await _unitOfWork.PersonaNaturalRepository.Delete(idPersona);
            _unitOfWork.SaveChanges();
        }
    }
}
