using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class BaseRepositoryTwoIds<T> : BaseRepository<T>, IBaseRepositoryTwoIds<T> where T : BaseEntityTwoIds
    {
        public BaseRepositoryTwoIds(SISDETContext context) : base(context)
        {

        }
        public async Task AddGenerateIdTwo(T entity)
        {
            entity.IdTwo = GetNewIdTwoById(entity.Id);
            await _entities.AddAsync(entity);

            _context.SaveChanges();
        }
        public async Task DeleteByIds(int id, int idTwo)
        {
            T entity = await GetByIds(id, idTwo);

            _context.Remove(entity);
        }

        public async Task DeletesById(int id)
        {
            IEnumerable<T> entities = await GetsById(id);

            _context.RemoveRange(entities);
        }

        public async Task<T> GetByIds(int id, int idTwo)
        {
            return await _entities.Where(x => x.Id == id && x.IdTwo == idTwo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetsById(int id)
        {
            return await _entities.Where(x => x.Id == id).ToListAsync();
        }
        public async Task<IEnumerable<T>> GetsByIdTwo(int idTwo)
        {
            return await _entities.Where(x => x.IdTwo == idTwo).ToListAsync();
        }
        public int GetNewIdTwoById(int id)
        {
            IQueryable<NumeroEnteroDto> listado =
                from pd in _entities
                where pd.Id == id
                select new NumeroEnteroDto { Numero = pd.IdTwo };

            NumeroEnteroDto item = listado.OrderByDescending(x => x.Numero).FirstOrDefault();

            return item == null ? 1 : item.Numero++;
        }

    }
}
