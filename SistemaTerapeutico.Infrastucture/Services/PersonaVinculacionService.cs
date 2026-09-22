using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaVinculacionService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PersonaVinculacionService(
            SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddPersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            PersonaVinculacion lPersonaVinculacion = await _context.GetByIds<PersonaVinculacion>(personaVinculacion.Id, personaVinculacion.Numero);

            if (lPersonaVinculacion != null)
            {
                throw new BusinessException("Ya existe una vinculación entre las personas.");
            }

            await _context.AddAsync(personaVinculacion);
            _context.SaveChanges();
        }
        public async Task DeletePersonasVinculacionesByIdPersona(int idPersona)
        {
            await _context.Delete<PersonaVinculacion>(idPersona);
            _context.SaveChanges();
        }

        public async Task DeletePersonaVinculacionByIds(int idPersona, int numero)
        {
            await _context.DeleteByIds<PersonaVinculacion>(idPersona, numero);
            _context.SaveChanges();
        }

        public IEnumerable<PersonaVinculacion> GetPersonasVinculaciones()
        {
            return _context.GetAll<PersonaVinculacion>();
        }

        public async Task<IEnumerable<PersonaVinculacion>> GetPersonasVinculacionesByIdPersona(int idPersona)
        {
            return await _context.GetsById<PersonaVinculacion>(idPersona);
        }

        public void UpdatePersonaVinculacion(PersonaVinculacion personaVinculacion)
        {
            _context.Update(personaVinculacion);
            _context.SaveChanges();
        }
    }
}
