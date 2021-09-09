using System;
using System.Collections.Generic;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;

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
            PersonaDireccion = new List<PersonaDireccionView>();
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
        public virtual List<PersonaContacto> PersonaContacto { get; set; }
        public virtual List<PersonaDireccionView> PersonaDireccion { get; set; }
        public virtual List<PersonaDocumento> PersonaDocumento { get; set; }
        public virtual List<PersonaVinculacion> PersonaVinculacion { get; set; }
        //public List<PersonaVinculacion> PersonaVinculacionIdPersonaVinculoNavigation { get; set; }
    }
}
