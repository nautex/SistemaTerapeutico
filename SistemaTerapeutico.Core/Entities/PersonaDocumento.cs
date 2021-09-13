using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDocumento : BaseEntityTwoIds
    {
        public PersonaDocumento()
        {
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
    }
}
