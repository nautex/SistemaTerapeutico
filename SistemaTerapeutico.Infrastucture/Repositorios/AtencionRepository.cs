using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AtencionRepository : BaseEntityRepository<Atencion>, IAtencionRepository
    {
        public AtencionRepository(SISDETContext context) : base(context)
        {

        }
    }
}
