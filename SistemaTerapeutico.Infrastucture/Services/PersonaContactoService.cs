using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaContactoService
    {
        private readonly SISDETContext _context;
        public PersonaContactoService(SISDETContext context)
        {
            _context = context;
        }

        public async Task AddPersonaContacto(PersonaContacto personaContacto)
        {
            await _context.AddAsync(personaContacto);
            _context.SaveChanges();
        }

        public async Task DeletePersonaContactoByIds(int idPersona, int numero)
        {
            await _context.DeleteByIds<PersonaContacto>(idPersona, numero);
            _context.SaveChanges();
        }

        public async Task DeletePersonasContactosByIdPersona(int idPersona)
        {
            await _context.DeletesById<PersonaContacto>(idPersona);
            _context.SaveChanges();
        }

        public IEnumerable<PersonaContacto> GetPersonasContactos()
        {
            return _context.GetAll<PersonaContacto>();
        }

        public async Task<IEnumerable<PersonaContacto>> GetPersonasContactosByIdPersona(int idPersona)
        {
            return await _context.GetsById<PersonaContacto>(idPersona);
        }

        public void UpdatePersonaContacto(PersonaContacto personaContacto)
        {
            _context.Update(personaContacto);
            _context.SaveChanges();
        }
    }
}
