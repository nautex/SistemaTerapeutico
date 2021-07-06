using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class DireccionRepository : BaseRepository<Direccion>, IDireccionRepository
    {
        public DireccionRepository(SISDETContext context) : base(context)
        {

        }
    }
}
