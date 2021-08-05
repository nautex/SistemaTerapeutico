namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPeriodo : BaseEntityTwoIds
    {
        public TerapiaPeriodo(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdModalidad { get; set; }
        public int IdComprobante { get; set; }
    }
}
