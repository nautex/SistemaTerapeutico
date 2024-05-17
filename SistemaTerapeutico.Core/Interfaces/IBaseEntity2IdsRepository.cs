using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseEntity2IdsRepository<T> : IBaseEntityRepository<T> where T : BaseEntity2Ids
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
