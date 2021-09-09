using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaDocumento : BaseEntityTwoIds
    {
        public PersonaDocumento()
        {
            IdEstado = EEstadoBasico.Activo;
        }
        public string Numero { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
    }
}
