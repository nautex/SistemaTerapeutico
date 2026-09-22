using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ConceptoCobroViewRepository : BaseRepositoryView<ConceptoCobroView>, IConceptoCobroViewRepository
    {
        public ConceptoCobroViewRepository(SISDETContext context) : base(context)
        {
        }
    }
}
