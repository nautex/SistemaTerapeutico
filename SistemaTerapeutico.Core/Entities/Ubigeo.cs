using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Ubigeo : BaseEntity
    {
        public Ubigeo()
        {
            PersonaDireccion = new HashSet<PersonaDireccion>();
            PersonaNatural = new HashSet<PersonaNatural>();
        }

        public string Codigo { get; set; }
        public int IdProvincia { get; set; }
        public int IdDepartamento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
        public virtual ICollection<PersonaNatural> PersonaNatural { get; set; }
    }
}
