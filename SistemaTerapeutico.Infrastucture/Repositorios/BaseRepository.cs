using System;
using System.Collections.Generic;
using System.Linq;
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
            entity.FechaRegistro = DateTime.Now;

            await _entities.AddAsync(entity);
        }
        public async Task AddAndSave(T entity)
        {
            entity.FechaRegistro = DateTime.Now;

            await _entities.AddAsync(entity);

            _context.SaveChanges();
        }
        public async Task<int> AddReturnId(T entity)
        {
            entity.FechaRegistro = DateTime.Now;

            await _entities.AddAsync(entity);

            _context.SaveChanges();

            return entity.Id;
        }

        public async Task Delete(int id)
        {
            var Entity = await GetById(id);
            _entities.Remove(Entity);
        }
        public async Task DeleteAndSave(int id)
        {
            var Entity = await GetById(id);
            _entities.Remove(Entity);
            _context.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public Task<T> GetById(int id)
        {
            return _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(T entity)
        {
            entity.FechaModificacion = DateTime.Now;

            _entities.Update(entity);
        }
        public void UpdateAndSave(T entity)
        {
            entity.FechaModificacion = DateTime.Now;

            _entities.Update(entity);

            _context.SaveChanges();
        }
    }
}
