using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanificacionRepository : IBaseEntityTwoIdsRepository<TerapiaPlanificacion>
    {
        Task<IEnumerable<TerapiaPlanificacion>> GetTerapiasPeriodosByIdTerapia(int idTerapia);
    }
}
