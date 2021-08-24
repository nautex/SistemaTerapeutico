using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IDireccionService
    {
        IEnumerable<Direccion> GetDirecciones();
        Task<Direccion> GetDireccionById(int idDireccion);
        Task<int> AddDireccion(Direccion direccion);
        void UpdateDireccion(Direccion direccion);
        Task DeleteDireccion(int idDireccion);
        IEnumerable<DireccionView> GetDireccionesViewByUbigeoYDetalle(int idUbigeo, string detalle);
    }
}
