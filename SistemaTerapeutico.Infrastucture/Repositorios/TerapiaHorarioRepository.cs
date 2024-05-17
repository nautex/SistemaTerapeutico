using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class TerapiaHorarioRepository : BaseEntity2IdsRepository<TerapiaHorario>, ITerapiaHorarioRepository
    {
        public TerapiaHorarioRepository(SISDETContext context) : base(context)
        {
        }
    }
}
