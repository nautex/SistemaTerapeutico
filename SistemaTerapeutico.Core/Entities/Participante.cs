using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public class Participante : BaseEntity
    {
        public Participante()
        {
            LugarCasoAccidente = "";
            DetalleHermanos = "";
            TieneDiagnostico = false;
            ParticipanteAlergia = new List<ParticipanteAlergia>();
            ParticipantePersonaAutorizada = new List<ParticipantePersonaAutorizada>();
        }
        public int IdPersona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string LugarCasoAccidente { get; set; }
        public int IdDireccionCasoAccidente { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }
        public virtual List<ParticipanteAlergia> ParticipanteAlergia { get; set; }
        public virtual List<ParticipantePersonaAutorizada> ParticipantePersonaAutorizada { get; set; }
    }
}
