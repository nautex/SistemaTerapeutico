using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IDireccionRepository : IBaseRepository<Direccion>
    {
        Task<IEnumerable<Direccion>> GetDireccionesByUbigeoYDetalle(int idUbigeo, string detalle);
    }
}
