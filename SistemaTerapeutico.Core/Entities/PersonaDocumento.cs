using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDocumento
    {
        public int IdPersona { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Numero { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
