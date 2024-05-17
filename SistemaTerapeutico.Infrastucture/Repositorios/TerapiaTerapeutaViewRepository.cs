using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaTerapeutaViewRepository : BaseEntity2IdsRepository<TerapiaTerapeutaView>, ITerapiaTerapeutaViewRepository
    {
        public TerapiaTerapeutaViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
