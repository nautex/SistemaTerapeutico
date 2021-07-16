using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaVinculacionRepository : BaseRepository<PersonaVinculacion>, IPersonaVinculacionRepository
    {
        public PersonaVinculacionRepository(SISDETContext _context) : base(_context)
        {

        }

        public void DeleteByIds(int id, int idPersonaVinculo)
        {
            var list = GetAll();
            PersonaVinculacion entity = list.Where(x => x.Id == id && x.IdPersonaVinculo == idPersonaVinculo).FirstOrDefault();

            _context.Remove(entity);
        }

        public void DeletesById(int id)
        {
            var list = GetAll();
            IEnumerable<PersonaVinculacion> entities = list.Where(x => x.Id == id);

            _context.RemoveRange(entities);
        }
    }
}
