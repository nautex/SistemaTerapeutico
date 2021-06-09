using System.Linq;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> Listar<T>() where T : class;
        T Obtener<T>(object id) where T : class;
        void Guardar();
        void Agregar<T>(T entidad) where T : class;
    }
}