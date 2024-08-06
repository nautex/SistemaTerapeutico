using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaPlanViewRepository : BaseEntityRepository<TerapiaPlanView>, ITerapiaPlanViewRepository
    {
        public TerapiaPlanViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
