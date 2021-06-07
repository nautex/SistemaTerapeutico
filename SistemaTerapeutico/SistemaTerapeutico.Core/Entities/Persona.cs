using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            PersonaContacto = new HashSet<PersonaContacto>();
            PersonaDireccion = new HashSet<PersonaDireccion>();
            PersonaDocumento = new HashSet<PersonaDocumento>();
            PersonaVinculacionIdPersonaNavigation = new HashSet<PersonaVinculacion>();
            PersonaVinculacionIdPersonaVinculoNavigation = new HashSet<PersonaVinculacion>();
        }

        public int IdPersona { get; set; }
        public int? IdTipoPersona { get; set; }
        public string Nombres { get; set; }
        public string RazonSocial { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? IdPaisOrigen { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual PersonaNatural PersonaNatural { get; set; }
        public virtual ICollection<PersonaContacto> PersonaContacto { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual ICollection<PersonaDocumento> PersonaDocumento { get; set; }
        public virtual ICollection<PersonaVinculacion> PersonaVinculacionIdPersonaNavigation { get; set; }
        public virtual ICollection<PersonaVinculacion> PersonaVinculacionIdPersonaVinculoNavigation { get; set; }
    }
}
