using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class SesionRepository : BaseEntityRepository<Sesion>, ISesionRepository
    {
        public SesionRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Sesion>> GetSesionesByIdTerapia(int idTerapia)
        {
            return await _entities.Where(x => x.IdTerapia == idTerapia).ToListAsync();
        }
        public async Task<IEnumerable<Sesion>> GetSesionesByIdPeriodoTerapia(int idPeriodoTerapia)
        {
            return await _entities.Where(x => x.IdPeriodo == idPeriodoTerapia).ToListAsync();
        }
    }
}
