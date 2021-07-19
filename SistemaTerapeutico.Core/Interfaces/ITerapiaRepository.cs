using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaRepository : IBaseRepository<Terapia>
    {
        Task<IEnumerable<Terapia>> GetTerapiasByIdAtencion(int idAtencion);
    }
}
