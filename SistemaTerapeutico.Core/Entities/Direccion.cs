using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Direccion : BaseEntity
    {
        public eUbigeo? IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public eEstadoBasico? IdEstado { get; set; }
    }
}
