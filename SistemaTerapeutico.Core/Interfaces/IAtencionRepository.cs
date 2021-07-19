using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IAtencionRepository : IBaseRepository<Atencion>
    {
        Task<Atencion> GetLastAtencionByIdParticipante(int idParticipante);
    }
}
