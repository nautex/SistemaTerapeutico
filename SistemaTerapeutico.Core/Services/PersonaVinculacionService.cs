using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
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
            await _unitOfWork.PersonaVinculacionRepository.Add(personaVinculacion);

            _unitOfWork.SaveChanges();
        }
        public void DeletePersonasVinculacionesByIdPersona(int idPersona)
        {
            _unitOfWork.PersonaVinculacionRepository.Delete(idPersona);
        }

        public void DeletePersonaVinculacionByIds(int idPersona, int idPersonaVinculo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculaciones()
        {
            return await _unitOfWork.PersonaVinculacionRepository.GetAll();
        }

        public Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionesByIdPersona(int idPersona)
        {
            throw new NotImplementedException();
        }

        public void UpdatePersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            throw new NotImplementedException();
        }
    }
}
