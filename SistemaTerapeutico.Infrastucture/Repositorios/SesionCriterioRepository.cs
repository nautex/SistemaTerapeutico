using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class SesionCriterioRepository : BaseRepositoryTwoIds<SesionCriterio>, ISesionCriterioRepository
    {
        public SesionCriterioRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<SesionCriterio>> GetSesionesCriteriosByIdSesion(int idSesion)
        {
            return await _entities.Where(x => x.Id == idSesion).ToListAsync();
        }
    }
}
