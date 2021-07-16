using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaDireccionServices : IPersonaDireccionService
    {
        //123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100
        private readonly IUnitOfWork _unitOfWork;
        public PersonaDireccionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPersonaDireccion(PersonaDireccion personaDireccion)
        {
            await _unitOfWork.PersonaDireccionRepository.Add(personaDireccion);
        }
        public void DeletePersonasDireccionesByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaDireccionRepository.DeletesById(idPersona);
        }
        public void DeletePersonaDirecccionByIds(int idPersona, int numero)
        {
            _unitOfWork.PersonaDireccionRepository.DeleteByIds(idPersona, numero);
        }
        //12345678910111213141516171819202122232425262728293031323334353637381139404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100
        //1al100
        public IEnumerable<PersonaDireccion> GetPersonasDirecciones()
        {
            return _unitOfWork.PersonaDireccionRepository.GetAll();
        }

        public void UpdatePersonaDireccion(PersonaDireccion personaDireccion)
        {
            _unitOfWork.PersonaDireccionRepository.Update(personaDireccion);
        }
        public Task<IEnumerable<PersonaDireccion>> GetPersonasDireccionesByIdPersona(int idPersona)
        {
            return _unitOfWork.PersonaDireccionRepository.GetsById(idPersona);
        }

        public Task<PersonaDireccion> GetPersonaDireccionByIds(int idPersona, int numero)
        {
            return _unitOfWork.PersonaDireccionRepository.GetByIds(idPersona, numero);
        }
    }
}
