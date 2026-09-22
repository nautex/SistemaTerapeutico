using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Entities
{
    public class PersonaRepresentante : BaseEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdRepresentante { get; set; }
        public int IdCargo { get; set; }
        public int IdEstadoLaboral { get; set; }
    }
}
