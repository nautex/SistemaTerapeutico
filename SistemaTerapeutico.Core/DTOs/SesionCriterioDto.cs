namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioDto
    {
        public int IdSesionCriterio { get; set; }
        public int IdSesion { get; set; }
        public int IdObjetivoCriterio { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
