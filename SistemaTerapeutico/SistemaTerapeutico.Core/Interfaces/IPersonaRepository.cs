using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetPersonas();
        Task<Persona> GetPersonaById(int pIdPersona);
        Task InsertPersona(Persona pPersona);
    }
}
