using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class AreaObjetivoRepository : BaseEntityRepository<AreaObjetivo>, IAreaObjetivoRepository
    {
        public AreaObjetivoRepository(SISDETContext context) : base(context)
        {
        }
    }
}
