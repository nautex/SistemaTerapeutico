using System;
using System.Collections.Generic;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Persona : BaseEntity
    {
        public Persona()
        {
            Nombres = "";
            EsEmpresa = false;
            IdEstado = EEstadoBasico.Activo;
            IdPaisOrigen = EPais.Peru;

            PersonaContacto = new List<PersonaContacto>();
            PersonaDireccion = new List<PersonaDireccion>();
            PersonaDocumento = new List<PersonaDocumento>();
            PersonaVinculacion = new List<PersonaVinculacion>();

            //PersonaVinculacionIdPersonaVinculoNavigation = new List<PersonaVinculacion>();
        }

        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdPaisOrigen { get; set; }
        public bool EsEmpresa { get; set; }
        public int IdEstado { get; set; }
        public virtual PersonaNatural PersonaNatural { get; set; }
        public virtual ICollection<PersonaContacto> PersonaContacto { get; set; }
        public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual ICollection<PersonaDocumento> PersonaDocumento { get; set; }
        public virtual ICollection<PersonaVinculacion> PersonaVinculacion { get; set; }
        //public List<PersonaVinculacion> PersonaVinculacionIdPersonaVinculoNavigation { get; set; }
    }
}
