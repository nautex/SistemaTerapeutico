using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseRepositoryView<T> where T : BaseView
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(int id);
    }
}