namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDocumentoDto
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
