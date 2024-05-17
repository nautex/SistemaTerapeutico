using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class BaseEntity2IdsRepository<T> : BaseEntityRepository<T>, IBaseEntity2IdsRepository<T> where T : BaseEntity2Ids
    {
        public BaseEntity2IdsRepository(SISDETContext context) : base(context)
        {

        }
        public async Task AddGenerateIdTwo(T entity)
        {
            entity.FechaRegistro = DateTime.Now;
            entity.Numero = GetNewIdTwoById(entity.Id);
            await _entities.AddAsync(entity);

            _context.SaveChanges();
        }
        public async Task DeleteByIds(int id, int idTwo)
        {
            T entity = await GetByIds(id, idTwo);

            _context.Remove(entity);
        }
        public async Task DeleteByIdsAndSave(int id, int idTwo)
        {
            T entity = await GetByIds(id, idTwo);
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeletesById(int id)
        {
            IEnumerable<T> entities = await GetsById(id);

            _context.RemoveRange(entities);
        }
        public async Task DeletesByIdAndSave(int id)
        {
            IEnumerable<T> entities = await GetsById(id);
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        public async Task<T> GetByIds(int id, int idTwo)
        {
            return await _entities.Where(x => x.Id == id && x.Numero == idTwo).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetsById(int id)
        {
            return await _entities.Where(x => x.Id == id).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetsByIdTwo(int idTwo)
        {
            return await _entities.Where(x => x.Numero == idTwo).AsNoTracking().ToListAsync();
        }
        public int GetNewIdTwoById(int id)
        {
            IQueryable<NumeroEnteroDto> listado =
                from pd in _entities
                where pd.Id == id
                select new NumeroEnteroDto { Numero = pd.Numero };

            NumeroEnteroDto item = listado.OrderByDescending(x => x.Numero).FirstOrDefault();

            return item == null ? 1 : ++item.Numero;
        }

    }
}
