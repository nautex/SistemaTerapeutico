using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaContactoService : IPersonaContactoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaContactoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPersonaContacto(PersonaContacto personaContacto)
        {
            await _unitOfWork.PersonaContactoRepository.Add(personaContacto);
            _unitOfWork.SaveChanges();
        }

        public void DeletePersonaContactoByIds(int idPersona, int numero)
        {
            _unitOfWork.PersonaContactoRepository.DeleteByIds(idPersona, numero);
            _unitOfWork.SaveChanges();
        }

        public void DeletePersonasContactosByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaContactoRepository.DeletesById(idPersona);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<PersonaContacto> GetPersonasContactos()
        {
            return _unitOfWork.PersonaContactoRepository.GetAll();
        }

        public async Task<IEnumerable<PersonaContacto>> GetPersonasContactosByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaContactoRepository.GetsById(idPersona);
        }

        public void UpdatePersonaContacto(PersonaContacto personaContacto)
        {
            _unitOfWork.PersonaContactoRepository.Update(personaContacto);
            _unitOfWork.SaveChanges();
        }
    }
}
