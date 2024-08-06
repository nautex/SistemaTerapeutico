using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class SesionTerapeutaRepository : BaseEntity2IdsRepository<SesionTerapeuta>, ISesionTerapeutaRepository
    {
        public SesionTerapeutaRepository(SISDETContext context) : base(context)
        {
        }
    }
}
