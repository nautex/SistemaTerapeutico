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
        public async Task AddGenerateNumero(T entity)
        {
            entity.Numero = GetNewNumeroById(entity.Id);

            await _entities.AddAsync(entity);

            _context.SaveChanges();
        }
        public async Task DeleteByIds(int id, int numero)
        {
            T entity = await GetByIds(id, numero);

            _context.Remove(entity);
        }

        public async Task DeletesById(int id)
        {
            IEnumerable<T> entities = await GetsById(id);

            _context.RemoveRange(entities);
        }

        public async Task<T> GetByIds(int id, int numero)
        {
            IQueryable<T> listado =
                from pd in _entities
                where pd.Id == id && pd.Numero == numero
                select pd;

            return await listado.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetsById(int id)
        {
            IQueryable<T> listado =
                from pd in _entities
                where pd.Id == id
                select pd;

            return await listado.ToListAsync();
        }
        public int GetNewNumeroById(int id)
        {
            IQueryable<NumeroEnteroDto> listado =
                from pd in _entities
                where pd.Id == id
                select new NumeroEnteroDto { Numero = pd.Numero };

            NumeroEnteroDto item = listado.OrderByDescending(x => x.Numero).FirstOrDefault();

            return item == null ? 1 : item.Numero + 1;
        }

    }
}
