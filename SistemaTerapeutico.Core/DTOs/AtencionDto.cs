using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AtencionDto
    {
        public int Id { get; set; }
        public int IdParticipante { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
