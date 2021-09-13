using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepositoryTwoIds<T> : IBaseRepository<T> where T : BaseEntityTwoIds
    {
        Task AddGenerateIdTwo(T entity);
        Task DeleteByIds(int id, int idTwo);
        Task DeleteByIdsAndSave(int id, int idTwo);
        Task<T> GetByIds(int id, int idTwo);
        Task DeletesById(int id);
        Task DeletesByIdAndSave(int id);
        Task<IEnumerable<T>> GetsById(int id);
        Task<IEnumerable<T>> GetsByIdTwo(int idTwo);
        int GetNewIdTwoById(int id);
    }
}
