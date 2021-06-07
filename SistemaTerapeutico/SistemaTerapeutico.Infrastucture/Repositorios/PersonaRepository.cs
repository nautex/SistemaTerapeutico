using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly SISDETContext _context;
        public PersonaRepository(SISDETContext pContext)
        {
            _context = pContext;
        }
        public async Task<IEnumerable<Persona>> GetPersonas()
        {
            var lPersonas = await _context.Persona.ToListAsync();

            return lPersonas;
        }

        public async Task<Persona> GetPersonaById(int pIdPersona)
        {
            return await _context.Persona.FirstOrDefaultAsync(x => x.IdPersona == pIdPersona);
        }
        public async Task InsertPersona(Persona pPersona)
        {
            _context.Persona.Add(pPersona);
            await _context.SaveChangesAsync();
        }
    }
}
