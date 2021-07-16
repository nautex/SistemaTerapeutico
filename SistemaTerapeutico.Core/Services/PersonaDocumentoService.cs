using System.Collections.Generic;
using System.Linq;
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

        public PersonaDocumento GetPersonaDocumentoByIds(int idPersona, int idTipoDocumento)
        {
            var listado = _unitOfWork.PersonaDocumentoRepository.GetAll();
            listado = listado.Where(x => x.Id == idPersona && x.IdTipoDocumento == idTipoDocumento);

            return listado.FirstOrDefault();
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentos()
        {
            return _unitOfWork.PersonaDocumentoRepository.GetAll();
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentosByIdPersona(int idPersona)
        {
            var listado = _unitOfWork.PersonaDocumentoRepository.GetAll();
            listado = listado.Where(x => x.Id == idPersona);

            return listado;
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numero)
        {
            var listado = _unitOfWork.PersonaDocumentoRepository.GetAll();
            listado = listado.Where(x => x.IdTipoDocumento == idTipoDocumento && x.Numero == numero);

            return listado;
        }

        public void UpdatePersonaDocumento(PersonaDocumento personaDocumento)
        {
            _unitOfWork.PersonaDocumentoRepository.Update(personaDocumento);
        }
    }
}
