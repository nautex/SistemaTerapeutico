using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AreaViewRepository : BaseEntityRepository<AreaView>, IAreaViewRepository
    {
        public AreaViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
