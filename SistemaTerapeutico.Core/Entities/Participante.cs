using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public class Participante : BaseEntity
    {
        public Participante()
        {
            TieneEscolaridad = false;
            TieneSeguro = false;
            DetalleSeguro = "";
            TieneHermanos = false;
            DetalleHermanos = "";
            DetalleConvivencia = "";
            TieneDiagnostico = false;
            AsisteATerapia = false;
            LugarCasoAccidente = "";
            ParticipanteAlergia = new List<ParticipanteAlergia>();
            ParticipantePersonaAutorizada = new List<ParticipantePersonaAutorizada>();
            ParticipanteNivelLenguaje = new List<ParticipanteNivelLenguaje>();
            PersonaVinculacion = new List<PersonaVinculacion>();
        }
        public int IdPersona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool? TieneEscolaridad { get; set; }
        public int? IdColegio { get; set; }
        public int? IdGradoColegio { get; set; }
        public bool TieneSeguro { get; set; }
        public int? IdTipoSeguro { get; set; }
        public string DetalleSeguro { get; set; }
        public bool? TieneHermanos { get; set; }
        public string DetalleHermanos { get; set; }
        public string DetalleConvivencia { get; set; }
        public bool? TieneDiagnostico { get; set; }
        public DateTime? FechaUltimoDiagnostico { get; set; }
        public bool? AsisteATerapia { get; set; }
        public int? IdTipoTerapia { get; set; }
        public string LugarCasoAccidente { get; set; }
        public int? IdDireccionCasoAccidente { get; set; }
        public virtual List<ParticipanteAlergia> ParticipanteAlergia { get; set; }
        public virtual List<ParticipantePersonaAutorizada> ParticipantePersonaAutorizada { get; set; }
        public virtual List<ParticipanteNivelLenguaje> ParticipanteNivelLenguaje { get; set; }
        public virtual List<PersonaVinculacion> PersonaVinculacion { get; set; }
    }
}
