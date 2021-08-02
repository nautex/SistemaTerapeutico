namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioDto
    {
        public int IdSesion { get; set; }
        public int IdObjetivoCriterio { get; set; }
        public int IdPuntuacionDetalle { get; set; }
        public string Usuario { get; set; }
    }
}
