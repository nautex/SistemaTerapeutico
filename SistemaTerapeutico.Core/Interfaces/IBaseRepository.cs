using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
    }
}
