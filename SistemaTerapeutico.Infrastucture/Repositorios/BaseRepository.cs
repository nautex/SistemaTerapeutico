using Microsoft.EntityFrameworkCore;
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
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected readonly SISDETContext _context;
        protected DbSet<T> _entities;
        public BaseRepository(SISDETContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public Task<T> GetById(int id)
        {
            return _entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
