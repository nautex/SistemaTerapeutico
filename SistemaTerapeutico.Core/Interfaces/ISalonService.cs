using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ISalonService
    {
        IEnumerable<SalonView> GetAll();
        IEnumerable<Lista> GetsListByIdLocal(int idLocal);
    }
}
