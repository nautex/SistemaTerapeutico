using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ILocalService
    {
        IEnumerable<LocalView> GetALl();
        IEnumerable<Lista> GetsList();
    }
}
