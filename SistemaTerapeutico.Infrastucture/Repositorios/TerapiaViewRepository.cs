using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaViewRepository : BaseRepositoryView<TerapiaView>, ITerapiaViewRepository
    {
        public TerapiaViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
