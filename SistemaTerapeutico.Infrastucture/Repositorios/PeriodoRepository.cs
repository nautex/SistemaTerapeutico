using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PeriodoRepository : BaseEntityRepository<Periodo>, IPeriodoRepository
    {
        public PeriodoRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo)
        {
            return await _entities.Where(x => x.IdTipo == idTipo).ToListAsync();
        }
    }
}
