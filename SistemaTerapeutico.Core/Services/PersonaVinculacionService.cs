using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaVinculacionService : IPersonaVinculacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaVinculacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddPersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            PersonaVinculacion lPersonaVinculacion = await _unitOfWork.PersonaVinculacionRepository.GetByIds(personaVinculacion.Id, personaVinculacion.IdTwo);

            if (lPersonaVinculacion != null)
            {
                throw new BusinessException("Ya existe una vinculación entre las personas.");
            }

            await _unitOfWork.PersonaVinculacionRepository.Add(personaVinculacion);
            _unitOfWork.SaveChanges();
        }
        public void DeletePersonasVinculacionesByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaVinculacionRepository.Delete(idPersona);
            _unitOfWork.SaveChanges();
        }

        public void DeletePersonaVinculacionByIds(int idPersona, int idPersonaVinculo)
        {
            _unitOfWork.PersonaVinculacionRepository.DeleteByIds(idPersona, idPersonaVinculo);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<PersonaVinculacion> GetPersonasVinculaciones()
        {
            return _unitOfWork.PersonaVinculacionRepository.GetAll();
        }

        public async Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionesByIdPersona(int idPersona)
        {
            return await _unitOfWork.PersonaVinculacionRepository.GetsById(idPersona);
        }

        public void UpdatePersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            _unitOfWork.PersonaVinculacionRepository.Update(personaVinculacion);
            _unitOfWork.SaveChanges();
        }
    }
}
