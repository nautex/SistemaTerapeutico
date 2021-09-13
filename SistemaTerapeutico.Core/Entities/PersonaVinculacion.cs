using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaVinculacion : BaseEntityTwoIds
    {
        public PersonaVinculacion()
        {
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdPersonaVinculo { get; set; }
        public int? IdTipoVinculo { get; set; }
        public int? IdEstado { get; set; }
    }
}
