using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Direccion : BaseEntity
    {
        public Direccion(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdUbigeo = eUbigeo.Tacna;
            Referencia = "";
            IdEstado = eEstadoBasico.Activo;
        }
        public eUbigeo? IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public eEstadoBasico? IdEstado { get; set; }
    }
}
