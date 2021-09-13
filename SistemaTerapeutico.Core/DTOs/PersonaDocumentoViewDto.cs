using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDocumentoViewDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int IdPersona { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
