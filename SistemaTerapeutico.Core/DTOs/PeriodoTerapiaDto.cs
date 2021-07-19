using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PeriodoTerapiaDto
    {
        public int IdTipo { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
