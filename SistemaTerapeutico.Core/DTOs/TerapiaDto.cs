using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaDto
    {
        public int IdTerapia { get; set; }
        public int IdAtencion { get; set; }
        public int IdTipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdLugar { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
