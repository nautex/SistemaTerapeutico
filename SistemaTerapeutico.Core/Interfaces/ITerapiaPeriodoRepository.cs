using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPeriodoRepository : IBaseEntityTwoIdsRepository<TerapiaPeriodo>
    {
        Task<IEnumerable<TerapiaPeriodo>> GetTerapiasPeriodosByIdTerapia(int idTerapia);
    }
}
