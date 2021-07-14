using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly SISDETContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(SISDETContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }
        public async Task<int> AddReturnId(T entity)
        {
            await _entities.AddAsync(entity);

            _context.SaveChanges();

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var Entity = await GetById(id);
            _entities.Remove(Entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
