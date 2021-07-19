using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IAtencionService
    {
        IEnumerable<Atencion> GetAtenciones();
        Task<Atencion> GetAtencionById(int idAtencion);
        Task<int> AddAtencion(Atencion Atencion);
        void UpdateAtencion(Atencion Atencion);
        Task DeleteAtencion(int idAtencion);
        Task<Atencion> GetLastAtencionByIdParticipante(int idParticipante);
    }
}
