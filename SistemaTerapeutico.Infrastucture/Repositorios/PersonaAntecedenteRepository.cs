using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class PersonaAntecedenteRepository : BaseEntity2IdsRepository<PersonaAntecedente>, IPersonaAntecedenteRepository
    {
        public PersonaAntecedenteRepository(SISDETContext context) : base(context)
        {
        }
    }
}
