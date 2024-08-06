using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AreaObjetivoCriterioViewRepository : BaseEntityRepository<AreaObjetivoCriterioView>, IAreaObjetivoCriterioViewRepository
    {
        public AreaObjetivoCriterioViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
