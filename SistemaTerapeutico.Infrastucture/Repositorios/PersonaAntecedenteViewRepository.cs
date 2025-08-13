using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaAntecedenteViewRepository : BaseEntity2IdsRepository<PersonaAntecedenteView>, IPersonaAntecedenteViewRepository
    {
        public PersonaAntecedenteViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
