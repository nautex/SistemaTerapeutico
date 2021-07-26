using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepositoryThreeIds<T> : IBaseRepositoryTwoIds<T> where T : BaseEntityThreeIds
    {
        Task DeleteByThreeIds(int id, int idTwo, int idThree);
        Task<T> GetByThreeIds(int id, int idTwo, int idThree);
    }
}
