using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaPlanAreaViewRepository : BaseEntity2IdsRepository<TerapiaPlanAreaView>, ITerapiaPlanAreaViewRepository
    {
        public TerapiaPlanAreaViewRepository(SISDETContext context) : base(context)
        {
        }
        public IEnumerable<Area> GetsArea(int idTerapia)
        {
            var list = from f in _context.TerapiaPlanAreaView
                where f.IdTerapia == idTerapia
                select new Area { Id = f.IdArea, Codigo = f.CodigoArea, Nombre = f.Area, IdModelo = 0, Descripcion = "", Orden = f.OrdenArea };

            return list.Distinct().OrderBy(x => x.Orden).ToList();
        }
    }
}
