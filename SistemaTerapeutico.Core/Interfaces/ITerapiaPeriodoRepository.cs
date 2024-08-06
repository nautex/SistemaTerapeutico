using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPeriodoRepository : IBaseEntityRepository<TerapiaPeriodo>
    {
        Task<IEnumerable<TerapiaPeriodo>> GetTerapiasPeriodosByIdPeriodoAndIdTerapiaAndNumero(int idPeriodo, int idTerapia, int numero);
    }
}
