using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanAreaViewRepository : IBaseEntity2IdsRepository<TerapiaPlanAreaView>
    {
        IEnumerable<Area> GetsArea(int idTerapia);
    }
}
