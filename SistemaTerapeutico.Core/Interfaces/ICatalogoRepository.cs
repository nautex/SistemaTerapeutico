﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ICatalogoRepository : IBaseEntityRepository<Catalogo>
    {
        Task<IEnumerable<Catalogo>> GetCatalogosByIdPadre(int idPadre);
        Task<IEnumerable<Lista>> GetCatalogosByIdPadreInLista(int idPadre);
    }
}
