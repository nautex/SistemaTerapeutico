using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IDireccionService
    {
        IEnumerable<Direccion> GetDirecciones();
        Task<Direccion> GetDireccionById(int idDireccion);
        Task<int> AddDireccion(Direccion direccion);
        void UpdateDireccion(Direccion direccion);
        Task DeleteDireccion(int idDireccion);
        Task<IEnumerable<Direccion>> GetDireccionsByUbigeoYDetalle(int idUbigeo, string detalle);
    }
}
