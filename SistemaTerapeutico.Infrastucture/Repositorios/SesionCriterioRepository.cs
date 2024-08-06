using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class SesionCriterioRepository : BaseEntity2IdsRepository<SesionCriterio>, ISesionCriterioRepository
    {
        public SesionCriterioRepository(SISDETContext context) : base(context)
        {
        }
    }
}
