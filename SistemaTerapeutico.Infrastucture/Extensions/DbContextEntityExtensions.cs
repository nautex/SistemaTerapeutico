using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Extensions
{
    public static class DbContextEntityExtensions
    {
        public static async Task Add<T>(
            this DbContext context,
            T entity)
            where T : BaseEntity
        {
            entity.FechaRegistro = DateTime.Now;

            await context.Set<T>()
                .AddAsync(entity);
        }

        public static async Task AddAndSave<T>(
            this DbContext context,
            T entity)
            where T : BaseEntity
        {
            entity.FechaRegistro = DateTime.Now;

            await context.Set<T>()
                .AddAsync(entity);

            await context.SaveChangesAsync();
        }
        public static async Task AddAndSaveAsync<T>(
            this DbContext context,
            T entity,
            string user)
            where T : BaseEntity
        {
            entity.FechaRegistro = DateTime.Now;
            entity.UsuarioRegistro = user;

            await context.Set<T>()
                .AddAsync(entity);

            await context.SaveChangesAsync();
        }

        public static async Task<int> AddReturnId<T>(
            this DbContext context,
            T entity)
            where T : BaseEntity
        {
            entity.FechaRegistro = DateTime.Now;

            await context.Set<T>()
                .AddAsync(entity);

            await context.SaveChangesAsync();

            return entity.Id;
        }
        public static async Task<int> AddReturnIdAsync<T>(
            this DbContext context,
            T entity,
            string user)
            where T : BaseEntity
        {
            entity.FechaRegistro = entity.FechaRegistro ?? DateTime.Now;
            entity.UsuarioRegistro = entity.UsuarioRegistro ?? user;
            entity.FechaRegistro = DateTime.Now;
            entity.UsuarioRegistro = user;

            await context.Set<T>()
                .AddAsync(entity);

            await context.SaveChangesAsync();

            return entity.Id;
        }

        public static async Task Delete<T>(
            this DbContext context,
            int id)
            where T : BaseEntity
        {
            T? entity =
                await context.GetById<T>(id);

            if (entity != null)
            {
                context.Set<T>()
                    .Remove(entity);
            }
        }

        public static async Task DeleteAndSave<T>(
            this DbContext context,
            int id)
            where T : BaseEntity
        {
            T? entity =
                await context.GetById<T>(id);

            if (entity != null)
            {
                context.Set<T>()
                    .Remove(entity);

                await context.SaveChangesAsync();
            }
        }

        public static void Update<T>(
            this DbContext context,
            T entity)
            where T : BaseEntity
        {
            entity.FechaModificacion = DateTime.Now;

            context.Set<T>()
                .Update(entity);
        }

        public static void UpdateAndSave<T>(
            this DbContext context,
            T entity)
            where T : BaseEntity
        {
            entity.FechaModificacion = DateTime.Now;

            context.Set<T>()
                .Update(entity);

            context.SaveChanges();
        }
        public static async Task UpdateAndSaveAsync<T>(
            this DbContext context,
            T entity,
            string user)
            where T : BaseEntity
        {
            entity.FechaModificacion = DateTime.Now;
            entity.UsuarioModificacion = user;

            context.Set<T>()
                .Update(entity);

            await context.SaveChangesAsync();
        }
        public static async Task Annull<T>(
            this DbContext context,
            int id)
            where T : BaseEntityActive
        {
            T? entity = await context.GetById<T>(id);

            if (entity != null)
            {
                entity.IdEstado = EEstadoBasico.Anulado;
                entity.FechaModificacion = DateTime.Now;

                context.Set<T>()
                    .Update(entity);

                await context.SaveChangesAsync();
            }
        }
        public static async Task Active<T>(
            this DbContext context,
            int id)
            where T : BaseEntityActive
        {
            T? entity = await context.GetById<T>(id);

            if (entity != null)
            {
                entity.IdEstado = EEstadoBasico.Activo;
                entity.FechaModificacion = DateTime.Now;

                context.Set<T>()
                    .Update(entity);

                await context.SaveChangesAsync();
            }
        }
    }
}
