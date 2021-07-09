using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDocumento : BaseEntity
    {
        public PersonaDocumento(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdEstado = (int)eEstadoBasico.Activo;
            UsuarioRegistro = usuarioRegistro;
        }
        public int IdTipoDocumento { get; set; }
        public string Numero { get; set; }
        public int? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
