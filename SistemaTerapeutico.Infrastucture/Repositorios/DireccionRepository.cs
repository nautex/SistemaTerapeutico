using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class DireccionRepository : BaseEntityRepository<Direccion>, IDireccionRepository
    {
        public DireccionRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Direccion>> GetDireccionesByUbigeoYDetalle(int idUbigeo, string detalle)
        {
            IQueryable<Direccion> listado =
                from d in _entities
                where d.IdUbigeo == idUbigeo && d.Detalle.Contains(detalle)
                select d;

            return await listado.ToListAsync();
        }
    }
}
