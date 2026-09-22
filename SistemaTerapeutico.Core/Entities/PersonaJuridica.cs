using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Entities
{
    public class PersonaJuridica : BaseEntity
    {
        public string RazonSocial { get; set; }
        public int? IdTipo { get; set; }
    }
}
