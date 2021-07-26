namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterio : BaseEntityTwoIds
    {
        public SesionCriterio(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdPuntuacionDetalle { get; set; }
    }
}
