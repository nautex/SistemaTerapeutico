namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPeriodo : BaseEntityTwoIds
    {
        public TerapiaPeriodo()
        {

        }
        public int IdModalidad { get; set; }
        public int IdComprobante { get; set; }
    }
}
