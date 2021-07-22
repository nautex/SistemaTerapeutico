namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterioActividad : BaseEntityTwoIds
    {
        public SesionCriterioActividad(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int Orden { get; set; }
        public string DetalleAplicacion { get; set; }
        public int IdPuntuacion { get; set; }
        public int Puntuacion { get; set; }
    }
}
