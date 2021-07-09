using System.Linq;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaContactoRepository : BaseRepository<PersonaContacto>, IPersonaContactoRepository
    {
        public PersonaContactoRepository(SISDETContext _context) : base(_context)
        {

        }
        public int GetNewNumeroByIdPersona(int idPersona)
        {
            IQueryable<NumeroEnteroDto> listado =
                from pd in _context.PersonaContacto
                where pd.Id == idPersona
                select new NumeroEnteroDto { Numero = pd.Numero };

            NumeroEnteroDto entidad = listado.OrderByDescending(x => x.Numero).FirstOrDefault();

            return entidad == null ? 1 : entidad.Numero + 1;
        }
    }
}