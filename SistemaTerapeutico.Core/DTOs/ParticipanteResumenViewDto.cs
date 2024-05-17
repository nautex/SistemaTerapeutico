using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteResumenViewDto : Base
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
