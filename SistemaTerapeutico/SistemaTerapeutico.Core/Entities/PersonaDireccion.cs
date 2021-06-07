using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDireccion
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int? IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ubigeo IdUbigeoNavigation { get; set; }
    }
}
