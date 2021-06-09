using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaContacto
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int? IdTipoContacto { get; set; }
        public string Valor { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
