using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class DestrezaRepository : BaseEntityRepository <Destreza>, IDestrezaRepository
    {
        public DestrezaRepository(SISDETContext context) : base(context)
        {
            
        }
    }
}
