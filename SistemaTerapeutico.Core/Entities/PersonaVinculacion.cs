using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaVinculacion : BaseEntityTwoIds
    {
        public PersonaVinculacion(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdEstado = EEstadoBasico.Activo;
        }
        public int? IdTipoVinculo { get; set; }
        public int? IdEstado { get; set; }
    }
}
