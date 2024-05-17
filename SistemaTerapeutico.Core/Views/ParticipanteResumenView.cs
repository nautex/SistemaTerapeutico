using SistemaTerapeutico.Core.Entities;
using System;

namespace SistemaTerapeutico.Core.Views
{
    public class ParticipanteResumenView : Base
    {
        public string Participante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdPadre { get; set; }
        public string Padre { get; set; }
        public int? IdMadre { get; set; }
        public string Madre { get; set; }
        public string LugarCasoAccidente { get; set; }
        public string PersonasAutorizadas { get; set; }
    }
}
