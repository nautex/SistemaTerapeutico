using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDireccion : BaseEntityTwoIds
    {
        public PersonaDireccion(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdTipoDireccion = ETipoDireccion.Domicilio;
            IdEstado = EEstadoBasico.Activo;
        }
        public int? IdDireccion { get; set; }
        public int? IdTipoDireccion { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
        //public virtual Direccion IdDireccionNavigation { get; set; }
    }
}
