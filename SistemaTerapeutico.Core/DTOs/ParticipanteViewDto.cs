using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteViewDto : BaseEntity
    {
        public int IdPersona { get; set; }
        public string Participante { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool? TieneEscolaridad { get; set; }
        public int? IdColegio { get; set; }
        public string Colegio { get; set; }
        public int? IdGradoColegio { get; set; }
        public string GradoColegio { get; set; }
        public bool? TieneSeguro { get; set; }
        public int? IdTipoSeguro { get; set; }
        public string TipoSeguro { get; set; }
        public string DetalleSeguro { get; set; }
        public bool? TieneHermanos { get; set; }
        public string DetalleHermanos { get; set; }
        public string DetalleConvivencia { get; set; }
        public bool? TieneDiagnostico { get; set; }
        public DateTime? FechaUltimoDiagnostico { get; set; }
        public bool? AsisteATerapia { get; set; }
        public int? IdTipoTerapia { get; set; }
        public string TipoTerapia { get; set; }
        public string LugarCasoAccidente { get; set; }
        public int? IdDireccionCasoAccidente { get; set; }
        public string UbigeoCasoAccidente { get; set; }
        public string DireccionCasoAccidente { get; set; }
        public virtual List<ParticipanteAlergia> ParticipanteAlergia { get; set; }
        public virtual List<ParticipantePersonaAutorizada> ParticipantePersonaAutorizada { get; set; }
        public virtual List<ParticipanteNivelLenguaje> ParticipanteNivelLenguaje { get; set; }
        public virtual List<PersonaVinculacionViewDto> PersonaVinculacion { get; set; }
    }
}
