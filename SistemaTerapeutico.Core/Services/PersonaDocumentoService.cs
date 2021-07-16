using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
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
            await _unitOfWork.PersonaDocumentoRepository.Add(personaDocumento);
        }

        public void DeletePersonaDocumentoByIds(int idPersona, int idTipoDocumento)
        {
            _unitOfWork.PersonaDocumentoRepository.DeleteByIds(idPersona, idTipoDocumento);
        }

        public void DeletePersonasDocumentosByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaDocumentoRepository.DeletesById(idPersona);
        }

        public Task<PersonaDocumento> GetPersonaDocumentoByIds(int idPersona, int idTipoDocumento)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetByIds(idPersona, idTipoDocumento);
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentos()
        {
            return _unitOfWork.PersonaDocumentoRepository.GetAll();
        }

        public Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByIdPersona(int idPersona)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetsById(idPersona);
        }

        public Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero)
        {
            return _unitOfWork.PersonaDocumentoRepository.GetPersonasDocumentosByTipoYNumero(idTipoDocumento, numero);
        }

        public void UpdatePersonaDocumento(PersonaDocumento personaDocumento)
        {
            _unitOfWork.PersonaDocumentoRepository.Update(personaDocumento);
        }
    }
}
