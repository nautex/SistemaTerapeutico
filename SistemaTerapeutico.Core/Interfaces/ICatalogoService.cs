using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ICatalogoService
    {
        Task<IEnumerable<Catalogo>> GetCatalogosByIdPadre(int idPadre);
    }
}
