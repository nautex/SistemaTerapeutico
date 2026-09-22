using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaRepresentanteView : BaseEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdRepresentante { get; set; }
        public string Representante { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
        public int IdEstadoLaboral { get; set; }
        public string EstadoLaboral { get; set; }
    }
}
