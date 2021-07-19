using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaTerapeutaService
    {
        Task AddTerapiaTerapeuta(TerapiaTerapeuta TerapiaTerapeuta);
        void DeleteTerapiasTerapeutasByIdAtencion(int idAtencion);
        void DeleteTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta);
        IEnumerable<TerapiaTerapeuta> GetTerapiasTerapeutas();
        void UpdateTerapiaTerapeuta(TerapiaTerapeuta TerapiaTerapeuta);
        Task<TerapiaTerapeuta> GetTerapiaTerapeutaByIds(int idAtencion, int idTerapeuta);
        Task<IEnumerable<TerapiaTerapeuta>> GetTerapiasTerapeutasByIdAtencion(int idAtencion);
    }
}
