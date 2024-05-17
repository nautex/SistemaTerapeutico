using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class BaseRepositoryView<T> : IBaseRepositoryView<T> where T : BaseEntity
    {
        protected readonly SISDETContext _context;
        protected DbSet<T> _entities;
        public BaseRepositoryView(SISDETContext context)
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
            return _entities.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
