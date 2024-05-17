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
    public class BaseEntityRepository<T> : BaseRepository<T>, IBaseEntityRepository<T> where T : BaseEntity
    {
        public BaseEntityRepository(SISDETContext context) : base(context)
        {
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
        public void Update(T entity)
        {
            entity.FechaModificacion = DateTime.Now;

            _entities.Update(entity);
        }
        public void UpdateAndSave(T entity)
        {
            entity.FechaModificacion = DateTime.Now;

            //_context.Entry(entity).State = EntityState.Modified;
            _entities.Update(entity);

            _context.SaveChanges();
        }
    }
}
