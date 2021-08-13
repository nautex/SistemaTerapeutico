using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaResumenViewDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public int IdTipoPersona { get; set; }
        public string TipoPersona { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }
}
