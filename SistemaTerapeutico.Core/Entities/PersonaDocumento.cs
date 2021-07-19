using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDocumento : BaseEntityTwoIds
    {
        public PersonaDocumento(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdEstado = EEstadoBasico.Activo;
            UsuarioRegistro = usuarioRegistro;
        }
        public string Numero { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
    }
}
