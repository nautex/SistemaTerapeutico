using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaService
    {
        IEnumerable<Terapia> GetTerapias();
        Task<Terapia> GetTerapiaById(int idTerapia);
        Task<int> AddTerapia(Terapia Terapia);
        void UpdateTerapia(Terapia Terapia);
        Task DeleteTerapia(int idTerapia);
        Task<IEnumerable<Terapia>> GetTerapiasByIdAtencion(int idAtencion);
    }
}
