using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IAtencionTerapiaService
    {
        Task AddAtencionTerapia(AtencionTerapia atencionTerapia);
        void DeleteAtencionesTerapiasByIdAtencion(int idAtencion);
        void DeleteAtencionTerapiaByIds(int idAtencion, int idTerapia);
        IEnumerable<AtencionTerapia> GetAtencionesTerapias();
        void UpdateAtencionTerapia(AtencionTerapia atencionTerapia);
        Task<IEnumerable<AtencionTerapia>> GetAtencionesTerapiasByIdAtencion(int idAtencion);
    }
}
