using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaDocumentoService : IPersonaDocumentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaDocumentoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPersonaDocumento(PersonaDocumento personaDocumento)
        {
            IEnumerable<PersonaDocumento> listado = await _unitOfWork.PersonaDocumentoRepository.GetPersonasDocumentosByTipoYNumero(personaDocumento.IdTipoDocumento, personaDocumento.NumeroDocumento);

            if (listado.Count() > 0)
            {
                throw new BusinessException("El tipo y numero de documento ya esta registrado.");
            }

            await _unitOfWork.PersonaDocumentoRepository.Add(personaDocumento);
            _unitOfWork.SaveChanges();
        }

        public void DeletePersonaDocumentoByIds(int idPersona, int numero)
        {
            _unitOfWork.PersonaDocumentoRepository.DeleteByIds(idPersona, numero);
            _unitOfWork.SaveChanges();
        }

        public void DeletePersonasDocumentosByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaDocumentoRepository.DeletesById(idPersona);
            _unitOfWork.SaveChanges();
        }

        public Task<PersonaDocumento> GetPersonaDocumentoByIds(int idPersona, int numero)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetByIds(idPersona, numero);
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentos()
        {
            return _unitOfWork.PersonaDocumentoRepository.GetAll();
        }

        public Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByIdPersona(int idPersona)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetsById(idPersona);
        }

        public Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numeroDocumento)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetPersonasDocumentosByTipoYNumero(idTipoDocumento, numeroDocumento);
        }

        public void UpdatePersonaDocumento(PersonaDocumento personaDocumento)
        {
            _unitOfWork.PersonaDocumentoRepository.Update(personaDocumento);
            _unitOfWork.SaveChanges();
        }
    }
}
