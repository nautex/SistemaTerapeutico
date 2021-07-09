using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaContacto : BaseEntity
    {
        public PersonaContacto(string usuarioRegistro) : base(usuarioRegistro)
        {
            UsuarioRegistro = usuarioRegistro;
            IdEstado = eEstadoBasico.Activo;
        }
        public int Numero { get; set; }
        public eTipoContacto? IdTipoContacto { get; set; }
        public string Valor { get; set; }
        public eEstadoBasico? IdEstado { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
