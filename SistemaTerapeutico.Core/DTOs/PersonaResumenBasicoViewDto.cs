namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaResumenBasicoViewDto
    {
        public int Id { get; set; }
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
