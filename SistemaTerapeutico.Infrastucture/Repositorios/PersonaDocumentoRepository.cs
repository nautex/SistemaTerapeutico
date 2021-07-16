using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDocumentoRepository : BaseRepository<PersonaDocumento>, IPersonaDocumentoRepository
    {
        public PersonaDocumentoRepository(SISDETContext _context) : base(_context)
        {

        }
        public void DeletesById(int id)
        {
            var list = GetAll();
            IEnumerable<PersonaDocumento> entities = list.Where(x => x.Id == id);

            _context.RemoveRange(entities);
        }
        public void DeleteByIds(int id, int idTipoDocumento)
        {
            var list = GetAll();
            PersonaDocumento entity = list.Where(x => x.Id == id && x.IdTipoDocumento == idTipoDocumento).FirstOrDefault();

            _context.Remove(entity);
        }
    }
}
