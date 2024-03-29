﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddAndSave(T entity);
        Task<int> AddReturnId(T entity);
        void Update(T entity);
        void UpdateAndSave(T entity);
        Task Delete(int id);
        Task DeleteAndSave(int id);
    }
}
