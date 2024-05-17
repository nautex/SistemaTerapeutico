using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IBaseViewEntity2IdsRepository<T> : IBaseEntity2IdsRepository<T> where T : BaseEntity2Ids
    {
    }
}
