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
    public class TerapiaPlanificacionRepository : BaseRepositoryTwoIds<TerapiaPlanificacion>, ITerapiaPlanificacionRepository
    {
        public TerapiaPlanificacionRepository(SISDETContext context) : base(context)
        {

        }
        public async Task<IEnumerable<TerapiaPlanificacion>> GetTerapiasPeriodosByIdTerapia(int idTerapia)
        {
            return await _entities.Where(x => x.Id == idTerapia).ToListAsync();
        }
    }
}
