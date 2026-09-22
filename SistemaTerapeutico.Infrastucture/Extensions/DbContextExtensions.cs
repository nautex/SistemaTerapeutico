using SistemaTerapeutico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Extensions
{
    public static class DbContextExtensions
    {
        public static IEnumerable<T> GetAll<T>(
            this DbContext context)
            where T : Base
        {
            return context.Set<T>()
                .AsNoTracking()
                .AsEnumerable();
        }
        public static async Task<IEnumerable<T>> GetAllAsync<T>(
            this DbContext context)
            where T : Base
        {
            return await context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }
        public static Task<T?> GetById<T>(
            this DbContext context,
            int id)
            where T : Base
        {
            return context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public static async Task<T?> GetByIdAsync<T>(
            this DbContext context,
            int id)
            where T : Base
        {
            return await context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
