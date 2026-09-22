using AutoMapper;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PersonaNaturalService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public PersonaNaturalService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<PersonaNatural> GetPersonasNaturales()
        {
            return _context.GetAll<PersonaNatural>();
        }
        public Task<PersonaNatural> GetPersonaNaturalById(int idPersona)
        {
            return _context.GetById<PersonaNatural>(idPersona);
        }
        public async Task AddPersonaNatural(PersonaNatural personaNatural)
        {
            await _context.AddAsync(personaNatural);
            _context.SaveChanges();
        }
        public void UpdatePersonaNatural(PersonaNatural personaNatural)
        {
            _context.Update(personaNatural);
            _context.SaveChanges();
        }
        public async Task DeletePersonaNatural(int idPersona)
        {
            await _context.Delete<PersonaNatural>(idPersona);
            _context.SaveChanges();
        }
    }
}
