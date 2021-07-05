using System;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaNatural : BaseEntity
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApelldio { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdNacionalidad { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNacimientoNavigation { get; set; }
    }
}
