using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{

    public class TerapiaPeriodoResumenViewRepository : BaseRepository<TerapiaPeriodoResumenView>, ITerapiaPeriodoResumenViewRepository
    {
        public TerapiaPeriodoResumenViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
