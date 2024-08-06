using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class SesionTerapeuta : BaseEntity2Ids
    {
        public int IdTerapeuta { get; set; }
        public int IdTipoCargo { get; set; }
    }
}
