using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaDocumentoService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PersonaDocumentoService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddPersonaDocumento(PersonaDocumento personaDocumento)
        {
            IEnumerable<PersonaDocumento> listado = await _context.PersonaDocumento.Where(x => x.IdTipoDocumento == personaDocumento.IdTipoDocumento && x.NumeroDocumento == personaDocumento.NumeroDocumento).ToListAsync();

            if (listado.Count() > 0)
            {
                throw new BusinessException("El tipo y numero de documento ya esta registrado.");
            }

            await _context.AddAsync(personaDocumento);
            _context.SaveChanges();
        }

        public async Task DeletePersonaDocumentoByIds(int idPersona, int numero)
        {
            await _context.DeleteByIds<PersonaDocumento>(idPersona, numero);
            _context.SaveChanges();
        }

        public async Task DeletePersonasDocumentosByIdPersona(int idPersona)
        {
            await _context.DeletesById<PersonaDocumento>(idPersona);
            _context.SaveChanges();
        }

        public Task<PersonaDocumento> GetPersonaDocumentoByIds(int idPersona, int numero)
        {
            return _context.GetByIds<PersonaDocumento>(idPersona, numero);
        }

        public IEnumerable<PersonaDocumento> GetPersonasDocumentos()
        {
            return _context.GetAll<PersonaDocumento>();
        }

        public Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByIdPersona(int idPersona)
        {
            return _context.GetsById<PersonaDocumento>(idPersona);
        }

        public async Task<IEnumerable<PersonaDocumento>> GetPersonasDocumentosByTipoYNumero(int idTipoDocumento, string numeroDocumento)
        {
            return await _context.PersonaDocumento.Where(x => x.IdTipoDocumento == idTipoDocumento && x.NumeroDocumento == numeroDocumento).ToListAsync();
        }

        public void UpdatePersonaDocumento(PersonaDocumento personaDocumento)
        {
            _context.Update(personaDocumento);
            _context.SaveChanges();
        }
    }
}
