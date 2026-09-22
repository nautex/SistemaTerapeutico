using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaJuridicaView : BaseEntity
    {
        public string Nombres { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdTipo { get; set; }
        public string Tipo { get; set; }
        public int? IdEstado { get; set; }
    }
}
