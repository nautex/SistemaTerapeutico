using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaDireccionServices
    {
        //123456789101112131415161718192021222324252627282930313233343536373839404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PersonaDireccionServices(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddPersonaDireccion(PersonaDireccion personaDireccion)
        {
            await _context.AddAsync(personaDireccion);
            _context.SaveChanges();
        }
        public async Task DeletePersonasDireccionesByIdPersona(int idPersona)
        {
            await _context.DeletesById<PersonaDireccion>(idPersona);
            _context.SaveChanges();
        }
        public async Task DeletePersonaDirecccionByIds(int idPersona, int numero)
        {
            await _context.DeleteByIds<PersonaDireccion>(idPersona, numero);
            _context.SaveChanges();
        }
        //12345678910111213141516171819202122232425262728293031323334353637381139404142434445464748495051525354555657585960616263646566676869707172737475767778798081828384858687888990919293949596979899100
        //1al100
        public IEnumerable<PersonaDireccion> GetPersonasDirecciones()
        {
            return _context.GetAll<PersonaDireccion>();
        }

        public void UpdatePersonaDireccion(PersonaDireccion personaDireccion)
        {
            _context.Update(personaDireccion);
            _context.SaveChanges();
        }
        public Task<IEnumerable<PersonaDireccion>> GetPersonasDireccionesByIdPersona(int idPersona)
        {
            return _context.GetsById<PersonaDireccion>(idPersona);
        }

        public Task<PersonaDireccion> GetPersonaDireccionByIds(int idPersona, int numero)
        {
            return _context.GetByIds<PersonaDireccion>(idPersona, numero);
        }
    }
}
