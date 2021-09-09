namespace SistemaTerapeutico.Core.Entities
{
    public class SesionCriterioActividad : BaseEntityThreeIds
    {
        public SesionCriterioActividad()
        {
            DetalleAplicacion = "";
        }
        public int Orden { get; set; }
        public string DetalleAplicacion { get; set; }
        public int IdPuntuacionDetalle { get; set; }
    }
}
