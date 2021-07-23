using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionDto
    {
        public int IdSesion { get; set; }
        public int IdTerapia { get; set; }
        public int IdPeriodoTerapia { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public int IdPuntuacion { get; set; }
        public string Observacion { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
