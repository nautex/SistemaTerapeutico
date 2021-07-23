namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterioActividad : BaseEntityTwoIds
    {
        public SesionCriterioActividad(string usuarioRegistro) : base(usuarioRegistro)
        {
            DetalleAplicacion = "";
        }
        public int Orden { get; set; }
        public string DetalleAplicacion { get; set; }
        public int Puntuacion { get; set; }
    }
}
