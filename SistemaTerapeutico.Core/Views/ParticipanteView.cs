using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class ParticipanteView : BaseEntity
    {
        public int IdPersona { get; set; }
        public string Participante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Padre { get; set; }
        public string Madre { get; set; }
        public string LugarCasoAccidente { get; set; }
        public int IdDireccionCasoAccidente { get; set; }
        public string UbigeoCasoAccidente { get; set; }
        public string DireccionCasoAccidente { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }
    }
}
