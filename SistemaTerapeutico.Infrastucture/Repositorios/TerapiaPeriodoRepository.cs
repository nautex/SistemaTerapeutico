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
    public class TerapiaPeriodoRepository : BaseRepositoryTwoIds<TerapiaPeriodo>, ITerapiaPeriodoRepository
    {
        public TerapiaPeriodoRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<TerapiaPeriodo>> GetTerapiasPeriodosByIdTerapia(int idTerapia)
        {
            return await _entities.Where(x => x.Id == idTerapia).ToListAsync();
        }
    }
}
