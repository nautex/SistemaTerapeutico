﻿using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class SesionCriterioActividadRepository : BaseEntityThreeIdsRepository<SesionCriterioActividad>, ISesionCriterioActividadRepository
    {
        public SesionCriterioActividadRepository(SISDETContext context) : base(context)
        {

        }
    }
}
