using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaRepository : IBaseRepository<Persona>
    {
        Task<Persona> GetPersonaByNumeroDocumento(string numeroDocumento);
    }
}
