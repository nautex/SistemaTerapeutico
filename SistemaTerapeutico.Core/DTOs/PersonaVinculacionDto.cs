using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaVinculacionDto
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdPersonaVinculo { get; set; }
        public int IdTipoVinculo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
