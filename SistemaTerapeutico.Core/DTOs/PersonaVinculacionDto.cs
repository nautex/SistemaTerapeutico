namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaVinculacionDto
    {
        public int IdPersona { get; set; }
        public int IdPersonaVinculo { get; set; }
        public int IdTipoVinculo { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
