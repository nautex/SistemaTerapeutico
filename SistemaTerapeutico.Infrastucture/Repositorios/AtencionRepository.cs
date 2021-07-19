using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AtencionRepository : BaseRepository<Atencion>, IAtencionRepository
    {
        public AtencionRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<Atencion> GetLastAtencionByIdParticipante(int idParticipante)
        {
            Atencion entity = await _entities.Where(x => x.IdParticipante == idParticipante).OrderByDescending(x => x.FechaInicio).FirstOrDefaultAsync();

            return entity;
        }
    }
}
