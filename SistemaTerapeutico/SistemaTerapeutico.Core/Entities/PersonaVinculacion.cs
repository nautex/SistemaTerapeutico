using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaVinculacion
    {
        public int IdPersona { get; set; }
        public int IdPersonaVinculo { get; set; }
        public int? IdTipoVinculo { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Persona IdPersonaVinculoNavigation { get; set; }
    }
}
