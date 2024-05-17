using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaHorarioViewRepository : BaseEntity2IdsRepository<TerapiaHorarioView>, ITerapiaHorarioViewRepository
    {
        public TerapiaHorarioViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
