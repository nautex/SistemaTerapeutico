using System;
using System.Collections.Generic;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Persona : BaseEntity
    {
        public Persona(string usuarioRegistro) : base(usuarioRegistro)
        {
            Nombres = "";
            RazonSocial = "";
            EsEmpresa = false;
            IdEstado = eEstadoBasico.Activo;

            PersonaContacto = new HashSet<PersonaContacto>();
            PersonaDireccion = new HashSet<PersonaDireccion>();
            PersonaDocumento = new HashSet<PersonaDocumento>();
            PersonaVinculacionIdPersonaNavigation = new HashSet<PersonaVinculacion>();
            PersonaVinculacionIdPersonaVinculoNavigation = new HashSet<PersonaVinculacion>();
        }

        public string Nombres { get; set; }
        public string RazonSocial { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? IdPaisOrigen { get; set; }
        public int IdTipoPersona { get; set; }
        public bool EsEmpresa { get; set; }
        public eEstadoBasico? IdEstado { get; set; }
        public virtual PersonaNatural PersonaNatural { get; set; }
        public virtual ICollection<PersonaContacto> PersonaContacto { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual ICollection<PersonaDocumento> PersonaDocumento { get; set; }
        public virtual ICollection<PersonaVinculacion> PersonaVinculacionIdPersonaNavigation { get; set; }
        public virtual ICollection<PersonaVinculacion> PersonaVinculacionIdPersonaVinculoNavigation { get; set; }
    }
}
