﻿using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaResumenViewRepository : BaseRepositoryView<PersonaResumenView>, IPersonaResumenViewRepository
    {

        public PersonaResumenViewRepository(SISDETContext context) : base(context)
        {

        }
    }
}
