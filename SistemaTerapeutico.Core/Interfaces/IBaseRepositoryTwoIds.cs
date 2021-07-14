using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepositoryTwoIds<T> where T : BaseEntityTwoIds
    {
        Task AddGenerateNumero(T entity);
        Task DeleteByIds(int id, int numero);
        Task<T> GetByIds(int id, int numero);
        Task DeletesById(int id);
        Task<IEnumerable<T>> GetsById(int id);
        int GetNewNumeroById(int id);
    }
}
