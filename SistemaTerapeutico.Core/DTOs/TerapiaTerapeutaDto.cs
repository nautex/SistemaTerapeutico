using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaTerapeutaDto
    {
        public int IdTerapia { get; set; }
        public int IdTerapeuta { get; set; }
        public int IdTipoCargo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
