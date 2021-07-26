using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaPlanificacionCriterioRepository : BaseRepositoryThreeIds<TerapiaPlanificacionCriterio>, ITerapiaPlanificacionCriterioRepository
    {
        public TerapiaPlanificacionCriterioRepository(SISDETContext context) : base(context)
        {

        }
        public void DeleteTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            var list = _entities.Where(x => x.Id == idTerapia && x.IdTwo == idPeriodo).ToList();
            _entities.RemoveRange(list);
        }

        public async Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia)
        {
            return await _entities.Where(x => x.Id == idTerapia).ToListAsync();
        }

        public async Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            return await _entities.Where(x => x.Id == idTerapia && x.IdTwo == idPeriodo).ToListAsync();
        }
    }
}
