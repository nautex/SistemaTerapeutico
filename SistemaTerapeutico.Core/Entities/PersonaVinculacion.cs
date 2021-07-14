using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaVinculacion : BaseEntity
    {
        public PersonaVinculacion(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdPersonaVinculo { get; set; }
        public int? IdTipoVinculo { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
        //public virtual Persona IdPersonaVinculoNavigation { get; set; }
    }
}
