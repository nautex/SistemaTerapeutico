using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;

namespace SistemaTerapeutico.Infrastucture.Extensions
{
    public static class DbContextEntityTwoKeysExtensions
    {
        public static async Task AddGenerateIdTwo<T>(
            this DbContext context,
            T entity)
            where T : BaseEntityTwoIds
        {
            entity.FechaRegistro = DateTime.Now;

            entity.Numero =
                context.GetNewIdTwoById<T>(entity.Id);

            await context.Set<T>()
                .AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public static async Task DeleteByIds<T>(
            this DbContext context,
            int id,
            int idTwo)
            where T : BaseEntityTwoIds
        {
            T? entity =
                await context.GetByIds<T>(
                    id,
                    idTwo);

            if (entity != null)
            {
                context.Remove(entity);
            }
        }

        public static async Task DeleteByIdsAndSave<T>(
            this DbContext context,
            int id,
            int idTwo)
            where T : BaseEntityTwoIds
        {
            T? entity =
                await context.GetByIds<T>(
                    id,
                    idTwo);

            if (entity != null)
            {
                context.Remove(entity);

                await context.SaveChangesAsync();
            }
        }
        public static async Task DeleteByIdAndSave<T>(
            this DbContext context,
            int id)
            where T : BaseEntity
        {
            T? entity =
                await context.GetById<T>(
                    id);

            if (entity != null)
            {
                context.Remove(entity);

                await context.SaveChangesAsync();
            }
        }
        public static async Task DeletesById<T>(
            this DbContext context,
            int id)
            where T : BaseEntityTwoIds
        {
            IEnumerable<T> entities =
                await context.GetsById<T>(id);

            context.RemoveRange(entities);
        }

        public static async Task DeletesByIdAndSave<T>(
            this DbContext context,
            int id)
            where T : BaseEntityTwoIds
        {
            IEnumerable<T> entities =
                await context.GetsById<T>(id);

            context.RemoveRange(entities);

            await context.SaveChangesAsync();
        }

        public static Task<T?> GetByIds<T>(
            this DbContext context,
            int id,
            int idTwo)
            where T : BaseEntityTwoIds
        {
            return context.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x =>
                    x.Id == id &&
                    x.Numero == idTwo);
        }

        public static async Task<IEnumerable<T>> GetsById<T>(
            this DbContext context,
            int id)
            where T : BaseEntityTwoIds
        {
            return await context.Set<T>()
                .Where(x => x.Id == id)
                .AsNoTracking()
                .ToListAsync();
        }
        public static async Task<IEnumerable<T>> GetsDetailById<T>(
            this DbContext context,
            int id)
            where T : BaseEntity
        {
            return await context.Set<T>()
                .Where(x => x.Id == id)
                .AsNoTracking()
                .ToListAsync();
        }

        public static async Task<IEnumerable<T>> GetsByIdTwo<T>(
            this DbContext context,
            int idTwo)
            where T : BaseEntityTwoIds
        {
            return await context.Set<T>()
                .Where(x => x.Numero == idTwo)
                .AsNoTracking()
                .ToListAsync();
        }

        public static int GetNewIdTwoById<T>(
            this DbContext context,
            int id)
            where T : BaseEntityTwoIds
        {
            IQueryable<NumeroEnteroDto> listado =
                from item in context.Set<T>()
                where item.Id == id
                select new NumeroEnteroDto
                {
                    Numero = item.Numero
                };

            NumeroEnteroDto? numero =
                listado
                .OrderByDescending(x => x.Numero)
                .FirstOrDefault();

            return numero == null
                ? 1
                : numero.Numero + 1;
        }
    }
}
