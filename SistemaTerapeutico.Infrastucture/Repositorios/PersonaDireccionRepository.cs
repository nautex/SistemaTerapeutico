using System.Linq;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaDireccionRepository : BaseRepository<PersonaDireccion>, IPersonaDireccionRepository
    {
        public PersonaDireccionRepository(SISDETContext context) : base(context)
        {

        }

        public int GetNewNumeroByIdPersona(int idPersona)
        {
            IQueryable<NumeroEnteroDto> listado =
                from pd in _context.PersonaDireccion
                where pd.Id == idPersona
                select new NumeroEnteroDto { Numero = pd.Numero };

            NumeroEnteroDto item = listado.OrderByDescending(x => x.Numero).FirstOrDefault();

            return item == null ? 1 : item.Numero + 1;
        }
    }
}
