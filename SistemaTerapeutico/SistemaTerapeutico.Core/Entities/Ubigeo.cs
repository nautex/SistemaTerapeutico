using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Ubigeo
    {
        public Ubigeo()
        {
            PersonaDireccion = new HashSet<PersonaDireccion>();
            PersonaNatural = new HashSet<PersonaNatural>();
        }

        public int IdUbigeo { get; set; }
        public string Codigo { get; set; }
        public int IdProvincia { get; set; }
        public int IdDepartamento { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual ICollection<PersonaNatural> PersonaNatural { get; set; }
    }
}
