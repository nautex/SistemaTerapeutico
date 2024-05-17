using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TarifaViewRepository : BaseRepositoryView<TarifaView>, ITarifaViewRepository
    {
        public TarifaViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
