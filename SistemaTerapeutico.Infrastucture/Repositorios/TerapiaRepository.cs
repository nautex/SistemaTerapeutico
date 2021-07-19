using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaRepository : BaseRepository<Terapia>, ITerapiaRepository
    {
        public TerapiaRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Terapia>> GetTerapiasByIdAtencion(int idAtencion)
        {
            return await _entities.Where(x => x.IdAtencion == idAtencion).ToListAsync();
        }
    }
}
