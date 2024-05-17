using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteDto : BaseEntity
    {
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
