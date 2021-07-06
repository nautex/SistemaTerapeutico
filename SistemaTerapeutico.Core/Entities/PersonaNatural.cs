using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaNatural : BaseEntity
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApelldio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public eUbigeo? IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public eEstadoCivil? IdEstadoCivil { get; set; }
        public ePais? IdNacionalidad { get; set; }
        public eTipoPersona? IdTipoPersona { get; set; }
        public eEstadoBasico? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNacimientoNavigation { get; set; }
    }
}
