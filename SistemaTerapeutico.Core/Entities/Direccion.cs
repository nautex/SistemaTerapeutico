using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Direccion : BaseEntity
    {
        public Direccion()
        {
            IdUbigeo = EUbigeo.Tacna;
            Referencia = "";
            IdEstado = EEstadoBasico.Activo;
        }
        public int? IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public int? IdEstado { get; set; }
        //public virtual ICollection<PersonaDireccion> PersonaDireccion { get; set; }
    }
}
