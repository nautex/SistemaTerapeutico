using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class BaseRepositoryThreeIds<T> : BaseRepositoryTwoIds<T>, IBaseRepositoryThreeIds<T> where T : BaseEntityThreeIds
    {
        public BaseRepositoryThreeIds(SISDETContext context) : base(context)
        {

        }
        public async Task DeleteByThreeIds(int id, int idTwo, int idThree)
        {
            T entity = await GetByThreeIds(id, idTwo, idThree);

            _context.Remove(entity);
        }

        public async Task<T> GetByThreeIds(int id, int idTwo, int idThree)
        {
            return await _entities.Where(x => x.Id == id && x.IdTwo == idTwo && x.IdThree == idThree).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
